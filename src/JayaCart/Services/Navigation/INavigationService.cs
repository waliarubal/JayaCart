using JayaCart.Models;
using System.Collections.Generic;

namespace JayaCart.Services.Navigation
{
    public interface INavigationService
    {
        IEnumerable<SidebarItemModel> GetSidebarItems();

        bool Navigate(SidebarItemModel item);
    }
}
