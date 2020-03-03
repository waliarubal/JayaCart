using JayaCart.DataAccess.Services;
using JayaCart.Mobile.Services;
using JayaCart.Mobile.Shared.Base;
using JayaCart.Mobile.Shared.Commands;
using JayaCart.Mobile.Views;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JayaCart.Mobile.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        ICommand _signIn, _createAccount;
        readonly INavigationService _navigationService;

        public HomeViewModel(INavigationService navigationService, IUserAccountService accountService)
        {
            _navigationService = navigationService;

            Task.Run(async () =>
            {
                var account = accountService.GetLocalAccount();
                if (account != null)
                    await _navigationService.Navigate(typeof(ArticlesView), replaceRoot: true);
            });
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

        async void CreateAccountAction()
        {
            await _navigationService.Navigate(typeof(CreateAccountView), true);
        }

        async void SignInAction()
        {
            await _navigationService.Navigate(typeof(SignInView), true);
        }
    }
}
