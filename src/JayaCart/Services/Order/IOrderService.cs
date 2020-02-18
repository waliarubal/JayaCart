using JayaCart.Mobile.Models;

namespace JayaCart.Mobile.Services
{
    public interface IOrderService
    {
        Order Cart { get; }

        void ClearCart();

        void AddToCart(Article article, long quantity);
    }
}
