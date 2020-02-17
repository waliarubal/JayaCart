using JayaCart.Models;
using JayaCart.Services;
using JayaCart.Shared.Base;
using JayaCart.Shared.Commands;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JayaCart.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        ICommand _signIn, _createAccount;
        readonly IUserAccountService _accountService;
        readonly INavigationService _navigationService;

        public SignInViewModel(IUserAccountService accountService, INavigationService navigationService)
        {
            _accountService = accountService;
            _navigationService = navigationService;

            Task.Run(async () => await SignOut());
        }

        public string PhoneNumber
        {
            get => Get<string>();
            set => Set(value);
        }

        public string Password
        {
            get => Get<string>();
            set => Set(value);
        }

        public bool IsPasswordShown
        {
            get => Get<bool>();
            set => Set(value);
        }

        public bool IsSignInPreserved
        {
            get => Get<bool>();
            set => Set(value);
        }

        public ICommand SignInCommand
        {
            get
            {
                if (_signIn == null)
                    _signIn = new RelayCommand(SignInAction);

                return _signIn;
            }
        }

        public ICommand CreateAccountCommand
        {
            get
            {
                if (_createAccount == null)
                    _createAccount = new RelayCommand(CreateAccountAction);

                return _createAccount;
            }
        }

        protected override string Validate()
        {
            if (string.IsNullOrWhiteSpace(PhoneNumber) || PhoneNumber.Length != 10)
                return "Mobile phone number must be ten characters long.";

            if (string.IsNullOrWhiteSpace(Password))
                return "Please enter your password.";

            return default;
        }

        async void CreateAccountAction()
        {
            await _navigationService.Navigate(ViewType.CreateAccount);
        }

        async void SignInAction()
        {
            Error = Validate();
            if (IsHavingError)
                return;

            try
            {
                var user = await _accountService.SignIn(PhoneNumber, Password, IsSignInPreserved);
                if (user != null)
                    await _navigationService.Navigate(ViewType.Products);
            }
            catch (ServiceException ex)
            {
                Error = ex.Message;
            }
        }

        async Task SignOut()
        {
            var user = _accountService.GetLocalAccount();
            if (user != null)
                await _accountService.SignOut();
        }
    }
}
