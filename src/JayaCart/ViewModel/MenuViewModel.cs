using JayaCart.Model;
using JayaCart.Shared.Base;
using JayaCart.Shared.Command;
using JayaCart.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace JayaCart.ViewModel
{
    public class MenuViewModel: ViewModelBase
    {
        ICommand _menuClick;

        public MenuViewModel()
        {
            Menus = new ObservableCollection<MenuItemModel>
            {
                new MenuItemModel("Home", typeof(ItemsView), "\uf015"),
                new MenuItemModel("Shopping Cart", typeof(ItemsView), "\uf07a"),
                new MenuItemModel("Your Orders", typeof(ItemsView), "\uf290"),
                new MenuItemModel("Your Account", typeof(ItemsView), "\uf007")
            };

            Account = new UserAccountModel
            {
                FullName = "Rubal Walia",
                PhoneNumber = "9928893416"
            };
        }

        public ObservableCollection<MenuItemModel> Menus { get; }

        public UserAccountModel Account { get; }

        public ICommand MenuClickCommand
        {
            get
            {
                if (_menuClick == null)
                    _menuClick = new RelayCommand<MenuItemModel>(MenuClickAction);

                return _menuClick;
            }
        }

        void MenuClickAction(MenuItemModel menu)
        {

        }
    }
}
