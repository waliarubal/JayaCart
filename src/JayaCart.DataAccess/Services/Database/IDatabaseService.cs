using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.DataAccess.Services
{
    public interface IDatabaseService
    {
        Task<T> Get<T>(string collectionName, string key) where T : new();

        Task<IReadOnlyCollection<T>> GetMany<T>(string collectionName) where T : new();

        Task<T> Insert<T>(string collectionName, string key, T record) where T : new();
    }
}
