using JayaCart.Services.UserAccount;
using JayaCart.Shared.Base;
using JayaCart.Shared.Commands;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JayaCart.ViewModels
{
    public class SignInViewModel: ViewModelBase
    {
        ICommand _signIn;
        readonly IUserAccountService _accountService;

        public SignInViewModel(IUserAccountService accountService)
        {
            _accountService = accountService;

            Task.Run(async() => await SignOut());
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

        async void SignInAction()
        {
            var user = await _accountService.SignIn(PhoneNumber, Password, IsSignInPreserved);
            if (user != null)
                return;
        }

        async Task SignOut()
        {
            var user = _accountService.GetLocalAccount();
            if (user != null)
                await _accountService.SignOut();
        }
    }
}
