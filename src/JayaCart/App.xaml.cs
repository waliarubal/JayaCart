using JayaCart.Mobile.Services;
using JayaCart.Mobile.Shared;
using JayaCart.Mobile.Shared.Services;
using Xamarin.Forms;
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
    }
}
