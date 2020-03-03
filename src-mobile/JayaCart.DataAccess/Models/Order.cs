using JayaCart.DataAccess.Base;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace JayaCart.DataAccess.Models
{
    public class Order: ModelBase
    {
        public Order()
        {
            Articles = new ObservableCollection<OrderArticle>();
            Articles.CollectionChanged += Articles_CollectionChanged;
        }

        ~Order()
        {
            Articles.CollectionChanged -= Articles_CollectionChanged;
        }

        public float Total
        {
            get => Get<float>();
            private set => Set(value);
        }

        public ObservableCollection<OrderArticle> Articles { get; }

        void Articles_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var total = Total;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (OrderArticle article in e.NewItems)
                        total += article.Total;
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (OrderArticle article in e.OldItems)
                        total -= article.Total;
                    break;

                case NotifyCollectionChangedAction.Replace:
                    foreach (OrderArticle article in e.OldItems)
                        total -= article.Total;
                    foreach (OrderArticle article in e.NewItems)
                        total += article.Total;
                    break;

                case NotifyCollectionChangedAction.Reset:
                    total = 0f;
                    break;
            }

            Total = total > 0f ? total : 0f;
        }
    }
}
