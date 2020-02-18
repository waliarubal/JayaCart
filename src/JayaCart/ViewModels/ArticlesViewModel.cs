using JayaCart.DataAccess.Models;
using JayaCart.DataAccess.Services;
using JayaCart.Mobile.Shared.Base;
using JayaCart.Mobile.Shared.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace JayaCart.Mobile.ViewModels
{
    public class ArticlesViewModel: ViewModelBase
    {
        ICommand _search, _addToCart;
        readonly IArticleService _articleService;

        public ArticlesViewModel(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public ObservableCollection<Article> Articles
        {
            get => Get<ObservableCollection<Article>>();
            private set => Set(value);
        }

        public Article SelectedArticle
        {
            get => Get<Article>();
            private set => Set(value);
        }

        public string SearchKeywoard
        {
            get => Get<string>();
            set => Set(value);
        }

        public ICommand SearchCommand
        {
            get
            {
                if (_search == null)
                    _search = new RelayCommand<string>(SearchAction);

                return _search;
            }
        }

        public ICommand AddToCartCommand
        {
            get
            {
                if (_addToCart == null)
                    _addToCart = new RelayCommand(AddToCart);

                return _addToCart;
            }
        }

        void AddToCart()
        {

        }

        async void SearchAction(string keywoard)
        {
            var products = await _articleService.Search(keywoard);
            Articles = new ObservableCollection<Article>(products);
        }
    }
}
