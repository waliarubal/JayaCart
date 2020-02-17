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

        public string Error
        {
            get => Get<string>();
            protected set
            {
                Set(value);
                RaisePropertyChanged(nameof(IsHavingError));
            }
        }

        public bool IsHavingError => !string.IsNullOrEmpty(Error);

        protected virtual string Validate()
        {
            return default;
        }

        #endregion
    }
}
