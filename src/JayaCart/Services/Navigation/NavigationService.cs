using JayaCart.Models;
using JayaCart.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JayaCart.Services.Navigation
{
    public class NavigationService: INavigationService
    {
        readonly Dictionary<ViewType, KeyValuePair<Type, bool>> _viewMapping;

        public NavigationService()
        {
            _viewMapping = new Dictionary <ViewType, KeyValuePair<Type, bool>>
            {
                [ViewType.About] = new KeyValuePair<Type, bool>(typeof(AboutView), false),
                [ViewType.Account] = new KeyValuePair<Type, bool>(typeof(AccountView), false),
                [ViewType.CreateAccount] = new KeyValuePair<Type, bool>(typeof(CreateAccountView), true),
                [ViewType.Login] = new KeyValuePair<Type, bool>(typeof(LoginView), true),
                [ViewType.Orders] = new KeyValuePair<Type, bool>(typeof(OrdersView), false),
                [ViewType.Products] = new KeyValuePair<Type, bool>(typeof(ProductsView), false),
                [ViewType.ShoppingCart] = new KeyValuePair<Type, bool>(typeof(ShoppingCartView), false)
            };
        }

        public IEnumerable<SidebarItemModel> GetSidebarItems()
        {
            var menus = new List<SidebarItemModel>
            {
                new SidebarItemModel("Home", ViewType.Products, "\uf015"),
                new SidebarItemModel("Shopping Cart", ViewType.ShoppingCart, "\uf07a"),
                new SidebarItemModel("Your Orders", ViewType.Orders, "\uf290"),
                new SidebarItemModel("Your Account", ViewType.Account, "\uf007"),
                new SidebarItemModel("Legal & About", ViewType.About, "\uf56c"),
                new SidebarItemModel("Sign Out", ViewType.Login, "\uf2f5")
            };
            return menus;
        }

        public async void Navigate(ViewType viewType)
        {
            var mainPage = Application.Current.MainPage as MasterDetailPage;
            if (mainPage == null)
                return;

            var view = Activator.CreateInstance(_viewMapping[viewType].Key) as Page;
            if (view == null)
                return;

            if (_viewMapping[viewType].Value)
                await mainPage.Navigation.PushModalAsync(view);
            else
            {
                mainPage.Detail = new NavigationPage(view);
                mainPage.IsPresented = false;
            }
        }
    }
}
