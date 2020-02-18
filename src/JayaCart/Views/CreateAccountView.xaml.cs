
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JayaCart.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountView : ContentPage
    {
        public CreateAccountView()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}