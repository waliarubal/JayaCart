using JayaCart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.Services.Navigation
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
        IEnumerable<SidebarItemModel> GetSidebarItems();

        Task Navigate(ViewType viewType);
    }
}
