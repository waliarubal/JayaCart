using JayaCart.DataAccess.Models;

namespace JayaCart.DataAccess.Services
{
    public class OrderService : IOrderService
    {
        public OrderService()
        {
            Cart = new Order();
        }

        public Order Cart { get; private set; }

        public void AddToCart(Article article, long quantity)
        {
            for (var index = 0; index < Cart.Articles.Count; index++)
            {
                var orderArticle = Cart.Articles[index];
                if (orderArticle.Article.Equals(article))
                {
                    if (quantity > 0)
                        orderArticle.Quantity = quantity;
                    else
                        Cart.Articles.RemoveAt(index);

                    return;
                }
            }

            var newOrderArticle = new OrderArticle
            {
                Article = article,
                Quantity = quantity
            };
            Cart.Articles.Add(newOrderArticle);
        }

        public void ClearCart()
        {
            Cart.Articles.Clear();
        }
    }
}
