using JayaCart.Shared.Base;
using System;

namespace JayaCart.Models
{
    public class SidebarItemModel: ModelBase
    {
        public SidebarItemModel(string title, Type viewType, string image = null, bool isViewModal = false)
        {
            Title = title;
            Image = image;
            ViewType = viewType;
            IsViewModal = isViewModal;
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

        public bool IsViewModal
        {
            get => Get<bool>();
            set => Set(value);
        }
    }
}
