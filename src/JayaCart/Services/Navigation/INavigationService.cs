using JayaCart.Mobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.Mobile.Services
{
    public enum ViewType: byte
    {
        SignIn,
        CreateAccount,
        Products,
        ShoppingCart,
        Orders,
        Account,
        About
    }

    public interface INavigationService
    {
        IEnumerable<SidebarItem> GetSidebarItems();

        Task Navigate(ViewType viewType);

        Task Close();

        Task Alert(string title, string message, string cancel = "Cancel");

        void ShowSidebar();
    }
}
