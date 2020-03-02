using JayaCart.DataAccess.Base;
using JayaCart.DataAccess.Models;
using JayaCart.DataAccess.Services;
using JayaCart.Mobile.Shared;

namespace JayaCart.Mobile.Models
{
    public class ShoppingCartArticle: ModelBase
    {
        IOrderService _orderService;

        public Article Article
        {
            get => Get<Article>();
            set => Set(value);
        }

        public long Quantity
        {
            get => Get<long>();
            set
            {
                if (Set(value))
                    UpdateCart();
            }        
        }

        IOrderService OrderService
        {
            get
            {
                if (_orderService == null)
                    _orderService = ViewModelLocator.Resolve<IOrderService>();

                return _orderService;
            }
        }

        void UpdateCart()
        {
            OrderService.AddToCart(Article, Quantity);
        }
    }
}
