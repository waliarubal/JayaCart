using Firebase.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.Mobile.Shared.Services
{
    public interface IDatabaseService
    {
        Task<T> Get<T>(string collectionName, string key);

        Task<IReadOnlyCollection<FirebaseObject<T>>> GetMany<T>(string collectionName);

        Task<T> Set<T>(string collectionName, string key, T record);
    }
}
