using Jaya.Cart.Views;
using Xamarin.Forms;

namespace Jaya.Cart
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new HostView();
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
