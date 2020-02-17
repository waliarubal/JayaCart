using JayaCart.Shared.Base;

namespace JayaCart.Models
{
    public class Product : ModelBase
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
    }
}
