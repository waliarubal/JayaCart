
using JayaCart.Mobile.Services;
using JayaCart.Mobile.Shared;
using JayaCart.Mobile.Shared.Commands;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JayaCart.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TitleBar : ContentView
    {
        public static readonly BindableProperty TitleProperty, IsModalProperty;
        INavigationService _navigationService;
        ICommand _showSidebar;

        static TitleBar()
        {
            TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(TitleBar), string.Empty, BindingMode.OneWay);
            IsModalProperty = BindableProperty.Create(nameof(IsModal), typeof(bool), typeof(TitleBar), true, BindingMode.OneWay);
        }

        public TitleBar()
        {
            InitializeComponent();
        }

        public ICommand ShowSidebarCommand
        {
            get
            {
                if (_showSidebar == null)
                    _showSidebar = new RelayCommand(ShowSidebarAction);

                return _showSidebar;
            }
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public bool IsModal
        {
            get => (bool)GetValue(IsModalProperty);
            set => SetValue(IsModalProperty, value);
        }

        void ShowSidebarAction()
        {
            if (!IsModal)
                return;

            if (_navigationService == null)
                _navigationService = ViewModelLocator.Resolve<INavigationService>();

            _navigationService.ShowSidebar();
        }
    }
}