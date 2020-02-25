using JayaCart.DataAccess.Models;
using JayaCart.DataAccess.Services;
using JayaCart.Mobile.Services;
using JayaCart.Mobile.Shared.Base;
using JayaCart.Mobile.Shared.Commands;
using JayaCart.Mobile.Views;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JayaCart.Mobile.ViewModels
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
            await _navigationService.Navigate(typeof(CreateAccountView), true);
        }

        async void SignInAction()
        {
            var error = Validate();
            if (error != null)
            {
                await _navigationService.Alert("Error", error);
                return;
            }

            try
            {
                var user = await _accountService.SignIn(PhoneNumber, Password);
                if (user != null)
                    await _navigationService.Navigate(typeof(ArticlesView));
            }
            catch (ServiceException ex)
            {
                error = ex.Message;
                await _navigationService.Alert("Error", error);
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
