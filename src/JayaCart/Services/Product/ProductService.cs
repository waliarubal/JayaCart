using System.Collections.Generic;
using System.Threading.Tasks;
using JayaCart.Models;

namespace JayaCart.Services
{
    public class ProductService : IProductService
    {
        public Task<IEnumerable<Product>> Search(string keywoard)
        {
            return Task.Run<IEnumerable<Product>>(() =>
            {
                var products = new List<Product>
                {
                    new Product { Code = "PR00031", Name = "PRM ROOM FRESHNER (L)", Packing = "125GM", MaximumRetailPrice = 125, Stock = 2 },
                    new Product { Code = "DE00025", Name = "DENVER DEO (CALIBER)", Packing = "165ML", MaximumRetailPrice = 210, Stock = 1 },
                    new Product { Code = "GL00016", Name = "GLYCINORM 40MG TABS", Packing = "10 TABS", MaximumRetailPrice = 43.32f, Stock = 2 },
                    new Product { Code = "PR00032", Name = "PRM ROOM FRESHNER (J)", Packing = "125GM", MaximumRetailPrice = 125, Stock = 1 },
                    new Product { Code = "GE00007", Name = "GEMS MONSTER 40/-", Packing = "39.9GM", MaximumRetailPrice = 40, Stock = 1 }
                };
                return products;
            });
        }
    }
}
