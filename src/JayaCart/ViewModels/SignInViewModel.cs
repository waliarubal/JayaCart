using JayaCart.Services.UserAccount;
using JayaCart.Shared.Base;
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

        public ICommand SignInCommand
        {
            get
            {
                if (_signIn == null)
                    _signIn = null;

                return _signIn;
            }
        }

        async Task SignOut()
        {
            var user = _accountService.GetSignedInAccount();
            if (user != null)
                await _accountService.SignOut();
        }
    }
}
