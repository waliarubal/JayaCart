﻿using JayaCart.Services.Navigation;
using JayaCart.Services.Settings;
using JayaCart.Services.UserAccount;
using JayaCart.Shared;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace JayaCart
{
    public partial class App : Application
    {
        void RegisterDependencies()
        {
            ViewModelLocator.RegisterSingleton<ISettingsService, SettingsService>();
            ViewModelLocator.RegisterSingleton<INavigationService, NavigationService>();
            ViewModelLocator.RegisterSingleton<IUserAccountService, UserAccountService>();
        }

        public App()
        {
            RegisterDependencies();
            InitializeComponent();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        internal static void Navigate(Type viewType)
        {
            var mainPage = Current.MainPage as MasterDetailPage;
            if (mainPage == null)
                return;

            var view = Activator.CreateInstance(viewType) as Page;
            if (view == null)
                return;

            mainPage.Detail = new NavigationPage(view);
            mainPage.IsPresented = false;
        }
    }
}
