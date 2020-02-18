using JayaCart.Models;

namespace JayaCart.Services
{
    public interface IOrderService
    {
        Order Cart { get; }

        void ClearCart();

        void AddToCart(Article article, long quantity);
    }
}
