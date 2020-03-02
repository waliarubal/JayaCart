using System.Collections.Generic;
using System.Threading.Tasks;
using JayaCart.DataAccess.Models;

namespace JayaCart.DataAccess.Services
{
    public class ArticleService : IArticleService
    {
        public Task<IEnumerable<Article>> Search(string keywoard)
        {
            return Task.Run<IEnumerable<Article>>(() =>
            {
                var products = new List<Article>
                {
                    new Article { Code = "PR00031", Name = "PRM ROOM FRESHNER (L)", Details = "125GM", Price = 125, Stock = 2 },
                    new Article { Code = "DE00025", Name = "DENVER DEO (CALIBER)", Details = "165ML", Price = 210, Stock = 1 },
                    new Article { Code = "GL00016", Name = "GLYCINORM 40MG TABS", Details = "10 TABS", Price = 43.32f, Stock = 2 },
                    new Article { Code = "PR00032", Name = "PRM ROOM FRESHNER (J)", Details = "125GM", Price = 125, Stock = 1 },
                    new Article { Code = "GE00007", Name = "GEMS MONSTER 40/-", Details = "39.9GM", Price = 40, Stock = 1 }
                };
                return products;
            });
        }
    }
}
