using JayaCart.Shared;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace JayaCart
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            ServiceLocator.Instance.DiscoverAndRegisterSingelton(Assembly.GetExecutingAssembly().GetTypes(), "Service");
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
