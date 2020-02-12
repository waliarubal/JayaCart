using JayaCart.Models;
using JayaCart.Services.Navigation;
using JayaCart.Services.UserAccount;
using JayaCart.Shared.Base;
using JayaCart.Shared.Commands;
using System.Collections.Generic;
using System.Windows.Input;

namespace JayaCart.ViewModels
{
    public class SidebarViewModel: ViewModelBase
    {
        ICommand _openView;
        readonly INavigationService _navigationService;
        readonly IUserAccountService _userAccountService;

        public SidebarViewModel(INavigationService navigationService, IUserAccountService userAccountService)
        {
            _navigationService = navigationService;
            _userAccountService = userAccountService;
        }

        public IEnumerable<SidebarItemModel> Items => _navigationService?.GetSidebarItems();

        public UserAccountModel Account => _userAccountService?.GetSavedAccount();

        public ICommand OpenViewCommand
        {
            get
            {
                if (_openView == null)
                    _openView = new RelayCommand<SidebarItemModel>(OpenViewAction);

                return _openView;
            }
        }

        void OpenViewAction(SidebarItemModel item)
        {
            if (item.IsViewModal)
                _navigationService.NavigateModal(item);
            else
                _navigationService.Navigate(item);
        }
    }
}
