namespace JayaCart.Shared.Base
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

        #endregion
    }
}
