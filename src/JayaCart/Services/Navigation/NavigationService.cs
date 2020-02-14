﻿using JayaCart.Models;
using JayaCart.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JayaCart.Services
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
                [ViewType.Products] = new KeyValuePair<Type, bool>(typeof(ProductsView), false),
                [ViewType.ShoppingCart] = new KeyValuePair<Type, bool>(typeof(ShoppingCartView), false)
            };
        }

        public async Task Close()
        {
            var mainPage = Application.Current.MainPage as MasterDetailPage;
            if (mainPage == null)
                return;

            if (mainPage.Navigation.ModalStack.Count > 0)
                await mainPage.Navigation.PopModalAsync();
        }

        public IEnumerable<SidebarItem> GetSidebarItems()
        {
            var menus = new List<SidebarItem>
            {
                new SidebarItem("Home", ViewType.Products, "\uf015"),
                new SidebarItem("Shopping Cart", ViewType.ShoppingCart, "\uf07a"),
                new SidebarItem("Your Orders", ViewType.Orders, "\uf290"),
                new SidebarItem("Your Account", ViewType.Account, "\uf007"),
                new SidebarItem("Legal & About", ViewType.About, "\uf56c"),
                new SidebarItem("Sign Out", ViewType.SignIn, "\uf2f5")
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
            {
                mainPage.Detail = new NavigationPage(view);
                mainPage.IsPresented = false;
            }
        }
    }
}