using JayaCart.Shared.Base;

namespace JayaCart.Models
{
    public class Order: ModelBase
    {
        public decimal Total
        {
            get => Get<decimal>();
            private set => Set(value);
        }
    }
}
