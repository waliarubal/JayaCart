using JayaCart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.Services.Navigation
{
    public enum ViewType: byte
    {
        Login,
        CreateAccount,
        Products,
        ShoppingCart,
        Orders,
        Account,
        About
    }

    public interface INavigationService
    {
        IEnumerable<SidebarItemModel> GetSidebarItems();

        Task Navigate(ViewType viewType);
    }
}
