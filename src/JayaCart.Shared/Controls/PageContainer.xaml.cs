
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JayaCart.Mobile.Shared.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageContainer : ContentView
    {
        public static readonly BindableProperty HeaderHeightProperty, BodyHeightProperty;

        static PageContainer()
        {
            var defaultHeaderHeight = new GridLength(0.25d, GridUnitType.Star);

            HeaderHeightProperty = BindableProperty.Create(nameof(HeaderHeight), typeof(GridLength), typeof(PageContainer), defaultHeaderHeight, BindingMode.OneWay);
        }

        public PageContainer()
        {
            InitializeComponent();
        }

        public GridLength HeaderHeight
        {
            get => (GridLength)GetValue(HeaderHeightProperty);
            set => SetValue(HeaderHeightProperty, value);
        }
    }
}