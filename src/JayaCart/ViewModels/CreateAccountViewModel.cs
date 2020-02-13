using JayaCart.Models;
using JayaCart.Services.Navigation;
using JayaCart.Services.UserAccount;
using JayaCart.Shared.Base;
using JayaCart.Shared.Commands;
using System.Windows.Input;

namespace JayaCart.ViewModels
{
    public class CreateAccountViewModel: ViewModelBase
    {
        readonly IUserAccountService _accountService;
        readonly INavigationService _navigationService;
        ICommand _createAccount;

        public CreateAccountViewModel(IUserAccountService accountService, INavigationService navigationService)
        {
            _accountService = accountService;
            _navigationService = navigationService;
        }

        public string FullName
        {
            get => Get<string>();
            set => Set(value);
        }

        public string PhoneNumber
        {
            get => Get<string>();
            set => Set(value);
        }

        public string Address
        {
            get => Get<string>();
            set => Set(value);
        }

        public string Password
        {
            get => Get<string>();
            set => Set(value);
        }

        public string ConfirmPassword
        {
            get => Get<string>();
            set => Set(value);
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

        async void CreateAccountAction()
        {
            var account = new UserAccountModel
            {
                PhoneNumber = PhoneNumber,
                FullName = FullName,
                Address = Address,
                Password = Password
            };

            var newAccount = await _accountService.Create(account);
            if (newAccount != null)
                await _navigationService.Close();
        }
    }
}
