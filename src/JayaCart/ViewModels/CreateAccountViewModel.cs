using JayaCart.Mobile.Models;
using JayaCart.Mobile.Services;
using JayaCart.Mobile.Shared.Base;
using JayaCart.Mobile.Shared.Commands;
using System;
using System.Windows.Input;

namespace JayaCart.Mobile.ViewModels
{
    public class CreateAccountViewModel : ViewModelBase
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

        protected override string Validate()
        {
            if (string.IsNullOrEmpty(FullName))
                return "Please enter your full name.";

            if (string.IsNullOrWhiteSpace(PhoneNumber) || PhoneNumber.Length != 10)
                return "Mobile phone number must be ten characters long.";

            if (string.IsNullOrWhiteSpace(Address))
                return "Please enter your address.";

            if (string.IsNullOrEmpty(Password) || Password.Length < 6)
                return "Password must be atleast six characters long.";

            if (string.IsNullOrEmpty(ConfirmPassword))
                return "Please confirm your password.";

            if (Password.Equals(ConfirmPassword, StringComparison.Ordinal))
                return "Invalid password confirmation. Reconfirm your password.";

            return base.Validate();
        }

        async void CreateAccountAction()
        {
            var error = Validate();
            if (error != null)
            {
                await _navigationService.Alert("Error", error);
                return;
            }

            var account = new UserAccount
            {
                PhoneNumber = PhoneNumber,
                FullName = FullName,
                Address = Address,
                Password = Password
            };

            try
            {
                var newAccount = await _accountService.Create(account);
                if (newAccount != null)
                    await _navigationService.Close();
            }
            catch (ServiceException ex)
            {
                await _navigationService.Alert("Error", error);
                error = ex.Message;
            }
        }
    }
}
