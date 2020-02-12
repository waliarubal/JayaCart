using JayaCart.Model;
using JayaCart.Services;
using JayaCart.Shared.Base;
using JayaCart.Shared.Command;
using System.Collections.Generic;
using System.Windows.Input;

namespace JayaCart.ViewModel
{
    public class SidebarViewModel: ViewModelBase
    {
        ICommand _openView;
        readonly NavigationService _navigationService;
        readonly UserAccountService _accountService;

        public SidebarViewModel()
        {
            _navigationService = Resolve<NavigationService>();
            _accountService = Resolve<UserAccountService>();

            Items = _navigationService?.GetSidebarItems();
            Account = _accountService?.GetSavedAccount();
        }

        public IEnumerable<SidebarItemModel> Items { get; }

        public UserAccountModel Account { get; }

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
            _navigationService.Navigate(item);
        }
    }
}
