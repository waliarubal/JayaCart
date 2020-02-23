using JayaCart.Mobile.Shared.Base;
using System;

namespace JayaCart.Mobile.Models
{
    public class SidebarItem: ModelBase
    {
        public SidebarItem(string title, Type viewType)
        {
            Title = title;
            ViewType = viewType;
        }

        public string Title
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
