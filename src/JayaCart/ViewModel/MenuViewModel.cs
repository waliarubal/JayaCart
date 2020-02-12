using JayaCart.Base;
using JayaCart.Model;
using JayaCart.View;
using System.Collections.ObjectModel;

namespace JayaCart.ViewModel
{
    public class MenuViewModel: ViewModelBase
    {
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

        public MenuItemModel SelectedMenu
        {
            get => Get<MenuItemModel>();
            set => Set(value);
        }
    }
}
