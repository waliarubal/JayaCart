
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jaya.Cart.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {
        public ListView ListView;

        public MenuView()
        {
            InitializeComponent();
        }
    }
}