using JayaCart.Models;
using JayaCart.Services.Navigation;
using JayaCart.Services.UserAccount;
using JayaCart.Shared.Base;
using JayaCart.Shared.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JayaCart.ViewModels
{
    public class SidebarViewModel : ViewModelBase
    {
        ICommand _itemClick;
        readonly INavigationService _navigationService;
        readonly IUserAccountService _accountService;

        public SidebarViewModel(INavigationService navigationService, IUserAccountService userAccountService)
        {
            _navigationService = navigationService;
            _accountService = userAccountService;

            Task.Run(async() => await SignIn());
        }

        public IEnumerable<SidebarItemModel> Items => _navigationService?.GetSidebarItems();

        public UserAccountModel Account
        {
            get => Get<UserAccountModel>();
            private set => Set(value);
        }

        public ICommand ItemClickCommand
        {
            get
            {
                if (_itemClick == null)
                    _itemClick = new RelayCommand<SidebarItemModel>(ItemClickAction);

                return _itemClick;
            }
        }

        async Task SignIn()
        {
            Account = _accountService.GetLocalAccount();
            if (Account == null)
                await _navigationService.Navigate(ViewType.SignIn);
        }

        async void ItemClickAction(SidebarItemModel item)
        {
            await _navigationService.Navigate(item.View);
        }
    }
}
