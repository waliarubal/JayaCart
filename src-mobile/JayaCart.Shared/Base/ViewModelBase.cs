using System.Threading.Tasks;

namespace JayaCart.Mobile.Shared.Base
{
    public abstract class ViewModelBase : ModelBase
    {
        protected ViewModelBase()
        {

        }

        #region properties

        public abstract bool IsCachable { get; }

        public bool IsBusy
        {
            get => Get<bool>();
            protected set => Set(value);
        }

        public bool IsLoaded
        {
            get => Get<bool>();
            internal set => Set(value);
        }

        protected virtual string Validate()
        {
            return default;
        }

        protected virtual void Clear()
        {

        }

        #endregion
    }
}
