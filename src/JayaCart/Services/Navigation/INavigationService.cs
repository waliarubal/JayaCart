using JayaCart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.Services.Navigation
{
    public interface INavigationService
    {
        IEnumerable<SidebarItemModel> GetSidebarItems();

        bool Navigate(SidebarItemModel item);

        Task<bool> NavigateModal(SidebarItemModel item);
    }
}
