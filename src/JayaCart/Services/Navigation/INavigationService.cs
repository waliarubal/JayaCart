using JayaCart.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.Mobile.Services
{
    public interface INavigationService
    {
        IEnumerable<SidebarItem> GetSidebarItems();

        Task Navigate(Type viewType, bool isModal = false);

        Task NavigateBack();

        Task Close();

        Task Alert(string title, string message, string cancel = "Cancel");

        void ShowSidebar();

        void Quit();
    }
}
