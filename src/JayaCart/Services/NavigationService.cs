using JayaCart.Model;
using JayaCart.View;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JayaCart.Services
{
    public sealed class NavigationService
    {
        public IEnumerable<SidebarItemModel> GetSidebarItems()
        {
            var menus = new List<SidebarItemModel>
            {
                new SidebarItemModel("Home", typeof(ProductsView), "\uf015"),
                new SidebarItemModel("Shopping Cart", typeof(LoginView), "\uf07a"),
                new SidebarItemModel("Your Orders", typeof(ProductsView), "\uf290"),
                new SidebarItemModel("Your Account", typeof(ProductsView), "\uf007")
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
