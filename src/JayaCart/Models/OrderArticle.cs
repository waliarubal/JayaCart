using JayaCart.Shared.Base;

namespace JayaCart.Models
{
    public class OrderArticle: ModelBase
    {
        public Article Article
        {
            get => Get<Article>();
            set
            {
                Set(value);
                RaisePropertyChanged(nameof(Total));
            }
        }

        public long Quantity
        {
            get => Get<long>();
            set
            {
                Set(value);
                RaisePropertyChanged(nameof(Total));
            }
        }

        public float Total => Quantity * (Article != null ? Article.MaximumRetailPrice : 0f);
    }
}
