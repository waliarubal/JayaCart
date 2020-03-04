
using JayaCart.Mobile.Services;
using JayaCart.Mobile.Shared;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JayaCart.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageContainer : ContentView
    {
        public static readonly BindableProperty
            HeaderHeightProperty,
            ContentMarginProperty,
            PageContentProperty,
            HeaderContentProperty, 
            IsNavigationAllowedProperty;

        static PageContainer()
        {
            HeaderHeightProperty = BindableProperty.Create(nameof(HeaderHeight), typeof(GridLength), typeof(PageContainer), new GridLength(0.25d, GridUnitType.Star), BindingMode.OneWay);
            ContentMarginProperty = BindableProperty.Create(nameof(ContentMargin), typeof(Thickness), typeof(PageContainer), new Thickness(32, 32, 32, 8), BindingMode.OneWay);
            PageContentProperty = BindableProperty.Create(nameof(PageContent), typeof(View), typeof(PageContainer));
            HeaderContentProperty = BindableProperty.Create(nameof(HeaderContent), typeof(View), typeof(PageContainer));
            IsNavigationAllowedProperty = BindableProperty.Create(nameof(IsNavigationAllowed), typeof(bool), typeof(TitleBar), true, BindingMode.OneWay);
        }

        public PageContainer()
        {
            InitializeComponent();

            var infoService = ViewModelLocator.Resolve<IInformationService>();
            if (infoService != null)
            {
                AppName = infoService.ApplicationName;
                AppVersion = infoService.ApplicationVersion;
            }
        }

        public string AppName { get; }

        public Version AppVersion { get; }

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

        public View HeaderContent
        {
            get => (View)GetValue(HeaderContentProperty);
            set => SetValue(HeaderContentProperty, value);
        }

        public bool IsNavigationAllowed
        {
            get => (bool)GetValue(IsNavigationAllowedProperty);
            set => SetValue(IsNavigationAllowedProperty, value);
        }
    }
}