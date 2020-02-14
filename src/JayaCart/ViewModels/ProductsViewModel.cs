using JayaCart.Models;
using JayaCart.Services;
using JayaCart.Shared.Base;
using JayaCart.Shared.Commands;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JayaCart.ViewModels
{
    public class ProductsViewModel: ViewModelBase
    {
        ICommand _search;
        readonly IProductService _productService;

        public ProductsViewModel(IProductService productService)
        {
            _productService = productService;

            Task.Run(() => SearchAction(string.Empty));
        }

        public ObservableCollection<Product> Products
        {
            get => Get<ObservableCollection<Product>>();
            private set => Set(value);
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

        async void SearchAction(string keywoard)
        {
            var products = await _productService.Search(keywoard);
            Products = new ObservableCollection<Product>(products);
        }
    }
}
