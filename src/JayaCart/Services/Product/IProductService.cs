using JayaCart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Search(string keywoard);
    }
}
