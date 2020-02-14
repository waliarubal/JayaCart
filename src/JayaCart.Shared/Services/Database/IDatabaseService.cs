using Firebase.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.Shared.Services
{
    public interface IDatabaseService
    {
        Task<T> Get<T>(string resourceName);

        Task<IReadOnlyCollection<FirebaseObject<T>>> GetMany<T>(string resourceName);

        Task<FirebaseObject<T>> Set<T>(string resourceName, T record);
    }
}
