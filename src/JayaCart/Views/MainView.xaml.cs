﻿
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JayaCart.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : MasterDetailPage
    {
        public MainView()
        {
            InitializeComponent();
            //MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as MainViewMenuItem;
        //    if (item == null)
        //        return;

        //    var page = (Page)Activator.CreateInstance(item.TargetType);
        //    page.Title = item.Title;

        //    Detail = new NavigationPage(page);
        //    IsPresented = false;

        //    MasterPage.ListView.SelectedItem = null;
        //}
    }
}