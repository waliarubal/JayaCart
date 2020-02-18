using JayaCart.DataAccess.Base;
using System;

namespace JayaCart.DataAccess.Models
{
    public class Article : ModelBase
    {
        public string Code
        {
            get => Get<string>();
            set => Set(value);
        }

        public string Name
        {
            get => Get<string>();
            set => Set(value);
        }

        public string Packing
        {
            get => Get<string>();
            set => Set(value);
        }

        public float MaximumRetailPrice
        {
            get => Get<float>();
            set => Set(value);
        }

        public long Stock
        {
            get => Get<long>();
            set
            {
                Set(value);
                RaisePropertyChanged(nameof(IsInStock));
            }
        }

        public bool IsInStock => Stock > 0;

        public override bool Equals(object obj)
        {
            var compareWith = obj as Article;
            if (compareWith == null)
                return false;

            return compareWith.Code.Equals(Code, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(Code))
                return default;

            return Code.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} ({Code})";
        }
    }
}
