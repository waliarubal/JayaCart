using JayaCart.DataAccess.Models;
using JayaCart.DataAccess.Services;
using JayaCart.Mobile.Shared.Base;

namespace JayaCart.Mobile.ViewModels
{
    public class ShoppingCartViewModel: ViewModelBase
    {
        readonly IOrderService _orderService;

        public ShoppingCartViewModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Order Cart => _orderService?.Cart;
    }
}
