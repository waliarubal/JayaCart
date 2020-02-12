using JayaCart.Models;
using JayaCart.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JayaCart.Services.Navigation
{
    public class NavigationService: INavigationService
    {
        public IEnumerable<SidebarItemModel> GetSidebarItems()
        {
            var menus = new List<SidebarItemModel>
            {
                new SidebarItemModel("Home", typeof(ProductsView), "\uf015"),
                new SidebarItemModel("Shopping Cart", typeof(ShoppingCartView), "\uf07a"),
                new SidebarItemModel("Your Orders", typeof(OrdersView), "\uf290"),
                new SidebarItemModel("Your Account", typeof(CreateAccountView), "\uf007"),
                new SidebarItemModel("Legal & About", typeof(AboutView), "\uf56c"),
                new SidebarItemModel("Sign Out", typeof(LoginView), "\uf2f5")
            };
            return menus;
        }

        public bool Navigate(SidebarItemModel item)
        {
            var mainPage = Application.Current.MainPage as MasterDetailPage;
            if (mainPage == null)
                return false;

            var view = Activator.CreateInstance(item.ViewType) as Page;
            if (view == null)
                return false;

            mainPage.Detail = new NavigationPage(view);
            mainPage.IsPresented = false;
            return true;
        }
    }
}
