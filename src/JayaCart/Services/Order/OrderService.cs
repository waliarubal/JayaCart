using JayaCart.Models;

namespace JayaCart.Services
{
    public class OrderService : IOrderService
    {
        public OrderService()
        {
            Cart = new Order();
        }

        public Order Cart { get; private set; }
    }
}
