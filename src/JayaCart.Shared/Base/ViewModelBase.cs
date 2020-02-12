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

        protected T Resolve<T>() where T : class
        {
            return ServiceLocator.Instance.Resolve<T>();
        }
    }
}
