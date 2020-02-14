using JayaCart.Services;
using JayaCart.Shared.Base;

namespace JayaCart.Models
{
    public class SidebarItem: ModelBase
    {
        public SidebarItem(string title, ViewType view, string icon = null)
        {
            Title = title;
            Icon = icon;
            View = view;
        }

        public string Title
        {
            get => Get<string>();
            set => Set(value);
        }

        public string Icon
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
