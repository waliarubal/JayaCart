using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.Shared.Services
{
    public class DatabaseService: IDatabaseService
    {
        const string DATABASE_URL = "https://jaya-cart-2020.firebaseio.com/";

        FirebaseClient GetClient()
        {
            var client = new FirebaseClient(DATABASE_URL);
            return client;
        }

        public async Task<T> Get<T>(string resourceName)
        {
            var client = GetClient();

            return await client
                .Child(resourceName)
                .OnceSingleAsync<T>();
        }

        public async Task<IReadOnlyCollection<FirebaseObject<T>>> GetMany<T>(string resourceName)
        {
            var client = GetClient();

            return await client
                .Child(resourceName)
                .OnceAsync<T>();
        }

        public async Task<FirebaseObject<T>> Set<T>(string resourceName, T record)
        {
            var client = GetClient();

            return await client.Child(resourceName).PostAsync(record);
        }
    }
}
