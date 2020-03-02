using JayaCart.Mobile.Shared.Base;
using System;

namespace JayaCart.Mobile.Models
{
    public class SidebarItem: ModelBase
    {
        public SidebarItem(string title, Type viewType, bool isModal = false, bool isRootView = false)
        {
            Title = title;
            ViewType = viewType;
            IsModal = isModal;
            IsRoot = isRootView;
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

        public bool IsRoot
        {
            get => Get<bool>();
            set => Set(value);
        }
    }
}
