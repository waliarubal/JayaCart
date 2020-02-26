using JayaCart.Mobile.Shared.Base;
using System;

namespace JayaCart.Mobile.Models
{
    public class SidebarItem: ModelBase
    {
        public SidebarItem(string title, Type viewType, bool isModal = false)
        {
            Title = title;
            ViewType = viewType;
            IsModal = isModal;
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

        public bool IsModal
        {
            get => Get<bool>();
            set => Set(value);
        }
    }
}
