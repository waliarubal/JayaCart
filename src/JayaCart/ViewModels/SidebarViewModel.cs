using JayaCart.DataAccess.Models;
using JayaCart.DataAccess.Services;
using JayaCart.Mobile.Models;
using JayaCart.Mobile.Services;
using JayaCart.Mobile.Shared.Base;
using JayaCart.Mobile.Shared.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace JayaCart.Mobile.ViewModels
{
    public class SidebarViewModel : ViewModelBase
    {
        ICommand _itemClick, _exit;
        readonly INavigationService _navigationService;
        readonly IUserAccountService _accountService;

        public SidebarViewModel(INavigationService navigationService, IUserAccountService userAccountService)
        {
            _navigationService = navigationService;
            _accountService = userAccountService;
        }

        public IEnumerable<SidebarItem> Items => _navigationService?.GetSidebarItems();

        public UserAccount Account => _accountService?.GetLocalAccount();

        public ICommand ItemClickCommand
        {
            get
            {
                if (_itemClick == null)
                    _itemClick = new RelayCommand<SidebarItem>(ItemClickAction);

                return _itemClick;
            }
        }

        public ICommand ExitCommand
        {
            get
            {
                if (_exit == null)
                    _exit = new RelayCommand(ExitAction);

                return _exit;
            }
        }

        void ExitAction()
        {
            _navigationService.Quit();
        }

        async void ItemClickAction(SidebarItem item)
        {
            await _navigationService.Navigate(item.ViewType, item.IsModal, item.IsRoot);
        }
    }
}
