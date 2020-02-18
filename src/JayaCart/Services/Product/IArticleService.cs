using JayaCart.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> Search(string keywoard);
    }
}
