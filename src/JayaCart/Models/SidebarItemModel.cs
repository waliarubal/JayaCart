using JayaCart.Services.Navigation;
using JayaCart.Shared.Base;

namespace JayaCart.Models
{
    public class SidebarItemModel: ModelBase
    {
        public SidebarItemModel(string title, ViewType view, string image = null)
        {
            Title = title;
            Image = image;
            View = view;
        }

        public string Title
        {
            get => Get<string>();
            set => Set(value);
        }

        public string Image
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
