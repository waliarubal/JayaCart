
using JayaCart.Mobile.Services;
using JayaCart.Mobile.Shared;
using JayaCart.Mobile.Shared.Commands;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JayaCart.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FooterBar : ContentView
    {
        INavigationService _navigationService;
        ICommand _navigate, _showSidebar;

        public FooterBar()
        {
            InitializeComponent();
        }

        INavigationService NavigationService
        {
            get
            {
                if (_navigationService == null)
                    _navigationService = ViewModelLocator.Resolve<INavigationService>();

                return _navigationService;
            }
        }

        public ICommand NavigateComand
        {
            get
            {
                if (_navigate == null)
                    _navigate = new RelayCommand<Type>(NavigateAction);

                return _navigate;
            }
        }

        public ICommand ShowSidebarComand
        {
            get
            {
                if (_showSidebar == null)
                    _showSidebar = new RelayCommand(ShowSidebarAction);

                return _showSidebar;
            }
        }

        void ShowSidebarAction()
        {
            NavigationService.ShowSidebar();
        }

        async void NavigateAction(Type viewType)
        {
            await NavigationService.Navigate(viewType);
        }
    }
}