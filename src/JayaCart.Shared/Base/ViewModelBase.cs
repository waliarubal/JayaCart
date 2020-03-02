namespace JayaCart.Mobile.Shared.Base
{
    public abstract class ViewModelBase : ModelBase
    {
        protected ViewModelBase()
        {

        }

        #region properties

        public bool IsBusy
        {
            get => Get<bool>();
            protected set => Set(value);
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
