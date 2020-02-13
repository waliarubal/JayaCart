using JayaCart.Models;
using JayaCart.Services;
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

        public IEnumerable<SidebarItem> Items => _navigationService?.GetSidebarItems();

        public UserAccount Account
        {
            get => Get<UserAccount>();
            private set => Set(value);
        }

        public ICommand ItemClickCommand
        {
            get
            {
                if (_itemClick == null)
                    _itemClick = new RelayCommand<SidebarItem>(ItemClickAction);

                return _itemClick;
            }
        }

        async Task SignIn()
        {
            Account = _accountService.GetLocalAccount();
            if (Account == null)
                await _navigationService.Navigate(ViewType.SignIn);
        }

        async void ItemClickAction(SidebarItem item)
        {
            await _navigationService.Navigate(item.View);
        }
    }
}
