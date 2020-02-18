
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JayaCart.Mobile.Shared.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageContainer : ContentView
    {
        public static readonly BindableProperty HeaderHeightProperty, ContentMarginProperty, PageContentProperty;

        static PageContainer()
        {
            HeaderHeightProperty = BindableProperty.Create(nameof(HeaderHeight), typeof(GridLength), typeof(PageContainer), new GridLength(0.25d, GridUnitType.Star), BindingMode.OneWay);
            ContentMarginProperty = BindableProperty.Create(nameof(ContentMargin), typeof(Thickness), typeof(PageContainer), new Thickness(32), BindingMode.OneWay);
            PageContentProperty = BindableProperty.Create(nameof(PageContent), typeof(View), typeof(PageContainer), null, BindingMode.TwoWay);
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

        public Thickness ContentMargin
        {
            get => (Thickness)GetValue(ContentMarginProperty);
            set => SetValue(ContentMarginProperty, value);
        }

        public View PageContent
        {
            get => (View)GetValue(PageContentProperty);
            set => SetValue(PageContentProperty, value);
        }
    }
}