using JayaCart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.Services
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
    }
}
