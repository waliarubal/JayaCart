using JayaCart.Services;
using JayaCart.Shared;
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
    }
}
