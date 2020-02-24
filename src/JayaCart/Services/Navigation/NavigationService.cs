using JayaCart.Mobile.Models;
using JayaCart.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JayaCart.Mobile.Services
{
    public class NavigationService : INavigationService
    {
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
                new SidebarItem("Store", typeof(ArticlesView)),
                new SidebarItem("Shopping Cart", typeof(ShoppingCartView)),
                new SidebarItem("Your Orders", typeof(OrdersView)),
                new SidebarItem("Your Account", typeof(AccountView)),
                new SidebarItem("About", typeof(AboutView)),
                new SidebarItem("Sign Out", typeof(SignInView))
            };

            return menus;
        }

        public async Task Navigate(Type viewType, bool isModal = false)
        {
            var mainPage = Application.Current.MainPage as MasterDetailPage;
            if (mainPage == null)
                return;

            var view = Activator.CreateInstance(viewType) as Page;
            if (view == null)
                return;

            await Close();

            if (isModal)
                await mainPage.Navigation.PushModalAsync(view);
            else
                await mainPage.Detail.Navigation.PushAsync(view);
        }

        public async Task NavigateBack()
        {
            var mainPage = Application.Current.MainPage as MasterDetailPage;
            if (mainPage == null)
                return;

            if (mainPage.Detail.Navigation.NavigationStack.Count > 0)
                await mainPage.Detail.Navigation.PopAsync();
        }

        public void Quit()
        {
            Process.GetCurrentProcess().CloseMainWindow();
        }

        public void ShowSidebar()
        {
            var mainPage = Application.Current.MainPage as MasterDetailPage;
            if (mainPage == null)
                return;

            mainPage.IsPresented = true;
        }
    }
}
