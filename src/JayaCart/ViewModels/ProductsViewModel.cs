using JayaCart.Models;
using JayaCart.Services;
using JayaCart.Shared.Base;
using JayaCart.Shared.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace JayaCart.ViewModels
{
    public class ProductsViewModel: ViewModelBase
    {
        ICommand _search, _addToCart;
        readonly IProductService _productService;

        public ProductsViewModel(IProductService productService)
        {
            _productService = productService;
        }

        public ObservableCollection<Product> Products
        {
            get => Get<ObservableCollection<Product>>();
            private set => Set(value);
        }

        public Product SelectedProduct
        {
            get => Get<Product>();
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
            var products = await _productService.Search(keywoard);
            Products = new ObservableCollection<Product>(products);
        }
    }
}
