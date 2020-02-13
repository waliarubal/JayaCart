using JayaCart.Models;
using System.Collections.Generic;

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

        void Navigate(ViewType viewType);
    }
}
