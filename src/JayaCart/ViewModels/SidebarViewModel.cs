using JayaCart.Models;
using JayaCart.Services.Navigation;
using JayaCart.Services.UserAccount;
using JayaCart.Shared.Base;
using JayaCart.Shared.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace JayaCart.ViewModels
{
    public class SidebarViewModel : ViewModelBase
    {
        ICommand _itemClick;
        readonly INavigationService _navigationService;
        readonly IUserAccountService _userAccountService;

        public SidebarViewModel(INavigationService navigationService, IUserAccountService userAccountService)
        {
            _navigationService = navigationService;
            _userAccountService = userAccountService;
        }

        public IEnumerable<SidebarItemModel> Items => _navigationService?.GetSidebarItems();

        public UserAccountModel Account => _userAccountService?.GetSignedInAccount();

        public ICommand ItemClickCommand
        {
            get
            {
                if (_itemClick == null)
                    _itemClick = new RelayCommand<SidebarItemModel>(ItemClickAction);

                return _itemClick;
            }
        }

        async void ItemClickAction(SidebarItemModel item)
        {
            if (item.View == ViewType.Login)
                await _userAccountService.SignOut();

            await _navigationService.Navigate(item.View);
        }
    }
}
