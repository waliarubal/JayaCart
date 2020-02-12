using JayaCart.Shared.Base;
using System;

namespace JayaCart.Models
{
    public class SidebarItemModel: ModelBase
    {
        public SidebarItemModel(string title, Type viewType, string image = null)
        {
            Title = title;
            Image = image;
            ViewType = viewType;
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

        public Type ViewType
        {
            get => Get<Type>();
            set => Set(value);
        }
    }
}
