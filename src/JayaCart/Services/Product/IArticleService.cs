using JayaCart.Mobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.Mobile.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> Search(string keywoard);
    }
}
