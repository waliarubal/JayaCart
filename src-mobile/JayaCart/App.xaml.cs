using JayaCart.DataAccess.Services;
using JayaCart.Mobile.Services;
using JayaCart.Mobile.Shared;
using JayaCart.Mobile.Shared.Services;
using JayaCart.Mobile.Views;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace JayaCart.Mobile
{
    public partial class App : Application
    {
        void RegisterDependencies()
        {
            ViewModelLocator.RegisterSingleton<ISettingsService, SettingsService>();
            ViewModelLocator.RegisterSingleton<IDatabaseService, DatabaseService>();
            ViewModelLocator.RegisterSingleton<INavigationService, NavigationService>();
            ViewModelLocator.RegisterSingleton<IUserAccountService, UserAccountService>();
            ViewModelLocator.RegisterSingleton<IArticleService, ArticleService>();
            ViewModelLocator.RegisterSingleton<IOrderService, OrderService>();
        }

        public App()
        {
            Log.Listeners.Add(new DelegateLogListener((value, category) => Debug.WriteLine(value, category)));
            InitializeComponent();
            RegisterDependencies();

            MainPage = new MainView();
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
    }
}
