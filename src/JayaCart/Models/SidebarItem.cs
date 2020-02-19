using JayaCart.Mobile.Services;
using JayaCart.Mobile.Shared.Base;

namespace JayaCart.Mobile.Models
{
    public class SidebarItem: ModelBase
    {
        public SidebarItem(string title, ViewType view)
        {
            Title = title;
            View = view;
        }

        public string Title
        {
            get => Get<string>();
            set => Set(value);
        }

        public ViewType View
        {
            get => Get<ViewType>();
            set => Set(value);
        }
    }
}
