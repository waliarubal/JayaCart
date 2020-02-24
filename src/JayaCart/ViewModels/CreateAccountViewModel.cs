using JayaCart.DataAccess.Models;
using JayaCart.DataAccess.Services;
using JayaCart.Mobile.Services;
using JayaCart.Mobile.Shared.Base;
using JayaCart.Mobile.Shared.Commands;
using JayaCart.Mobile.Views;
using System;
using System.Windows.Input;

namespace JayaCart.Mobile.ViewModels
{
    public class CreateAccountViewModel : ViewModelBase
    {
        readonly IUserAccountService _accountService;
        readonly INavigationService _navigationService;
        ICommand _createAccount, _signIn;

        public CreateAccountViewModel(IUserAccountService accountService, INavigationService navigationService)
        {
            _accountService = accountService;
            _navigationService = navigationService;
        }

        public string FirstName
        {
            get => Get<string>();
            set => Set(value);
        }

        public string LastName
        {
            get => Get<string>();
            set => Set(value);
        }

        public string PhoneNumber
        {
            get => Get<string>();
            set => Set(value);
        }

        public string AddressLine1
        {
            get => Get<string>();
            set => Set(value);
        }

        public string AddressLine2
        {
            get => Get<string>();
            set => Set(value);
        }

        public string City
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

        public bool IsPolicyAgreed
        {
            get => Get<bool>();
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

        public ICommand SignInCommand
        {
            get
            {
                if (_signIn == null)
                    _signIn = new RelayCommand(SignInAction);

                return _signIn;
            }
        }

        protected override string Validate()
        {
            if (string.IsNullOrEmpty(FirstName))
                return "Please enter your first name.";

            if (string.IsNullOrWhiteSpace(PhoneNumber) || PhoneNumber.Length != 10)
                return "Mobile phone number must be ten characters long.";

            if (string.IsNullOrWhiteSpace(AddressLine1))
                return "Please enter your address.";

            if (string.IsNullOrWhiteSpace(City))
                return "Please enter your city.";

            if (string.IsNullOrEmpty(Password) || Password.Length < 6)
                return "Password must be atleast six characters long.";

            if (string.IsNullOrEmpty(ConfirmPassword))
                return "Please confirm your password.";

            if (!Password.Equals(ConfirmPassword, StringComparison.Ordinal))
                return "Invalid password confirmation. Reconfirm your password.";

            if (!IsPolicyAgreed)
                return "Please agree to our conditions of use and privacy policy.";

            return base.Validate();
        }

        async void SignInAction()
        {
            await _navigationService.Navigate(typeof(SignInView), true);
        }

        async void CreateAccountAction()
        {
            var error = Validate();
            if (error != null)
            {
                await _navigationService.Alert("Error", error);
                return;
            }

            var account = new UserAccount(PhoneNumber)
            {
                FirstName = FirstName,
                LastName = LastName,
                AddressLine1 = AddressLine1,
                AddressLine2 = AddressLine2,
                City = City,
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
