using JayaCart.Mobile.Models;
using JayaCart.Mobile.Shared;
using JayaCart.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JayaCart.Mobile.Services
{
    public class NavigationService : INavigationService
    {
        readonly Dictionary<ViewType, KeyValuePair<Type, bool>> _viewMapping;

        public NavigationService()
        {
            _viewMapping = new Dictionary<ViewType, KeyValuePair<Type, bool>>
            {
                [ViewType.About] = new KeyValuePair<Type, bool>(typeof(AboutView), false),
                [ViewType.Account] = new KeyValuePair<Type, bool>(typeof(AccountView), false),
                [ViewType.CreateAccount] = new KeyValuePair<Type, bool>(typeof(CreateAccountView), true),
                [ViewType.SignIn] = new KeyValuePair<Type, bool>(typeof(SignInView), true),
                [ViewType.Orders] = new KeyValuePair<Type, bool>(typeof(OrdersView), false),
                [ViewType.Products] = new KeyValuePair<Type, bool>(typeof(ArticlesView), false),
                [ViewType.ShoppingCart] = new KeyValuePair<Type, bool>(typeof(ShoppingCartView), false)
            };
        }

        public async Task Alert(string title, string message, string cancel = "Cancel")
        {
            var mainPage = Application.Current.MainPage;
            if (mainPage == null)
                return;

            await mainPage.DisplayAlert(title, message, cancel);
        }

        public async Task Close()
        {
            var mainPage = Application.Current.MainPage as MasterDetailPage;
            if (mainPage == null)
                return;

            mainPage.IsPresented = false;
            if (mainPage.Navigation.ModalStack.Count > 0)
                await mainPage.Navigation.PopModalAsync();
        }

        public IEnumerable<SidebarItem> GetSidebarItems()
        {
            var menus = new List<SidebarItem>
            {
                new SidebarItem("Home", ViewType.Products),
                new SidebarItem("Shopping Cart", ViewType.ShoppingCart),
                new SidebarItem("Your Orders", ViewType.Orders),
                new SidebarItem("Your Account", ViewType.Account),
                new SidebarItem("Legal & About", ViewType.About),
                new SidebarItem("Sign Out", ViewType.SignIn)
            };

            return menus;
        }

        public async Task Navigate(ViewType viewType)
        {
            var mainPage = Application.Current.MainPage as MasterDetailPage;
            if (mainPage == null)
                return;

            var view = Activator.CreateInstance(_viewMapping[viewType].Key) as Page;
            if (view == null)
                return;

            await Close();

            if (_viewMapping[viewType].Value)
                await mainPage.Navigation.PushModalAsync(view);
            else
                mainPage.Detail = new NavigationPage(view);
        }
    }
}
