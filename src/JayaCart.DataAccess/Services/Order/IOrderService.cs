using JayaCart.DataAccess.Models;

namespace JayaCart.DataAccess.Services
{
    public interface IOrderService
    {
        Order Cart { get; }

        void ClearCart();

        void AddToCart(Article article, long quantity);
    }
}
