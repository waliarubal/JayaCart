using JayaCart.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.DataAccess.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> Search(string keywoard);
    }
}
