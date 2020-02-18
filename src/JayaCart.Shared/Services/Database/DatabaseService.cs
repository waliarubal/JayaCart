using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.Mobile.Shared.Services
{
    public class DatabaseService : IDatabaseService
    {
        const string DATABASE_URL = "https://jaya-cart-2020.firebaseio.com/";

        FirebaseClient GetClient()
        {
            var client = new FirebaseClient(DATABASE_URL);
            return client;
        }

        public async Task<T> Get<T>(string resourceName, string key)
        {
            var client = GetClient();

            return await client
                .Child(resourceName)
                .Child(key)
                .OnceSingleAsync<T>();
        }

        public async Task<IReadOnlyCollection<FirebaseObject<T>>> GetMany<T>(string collectionName)
        {
            var client = GetClient();

            return await client
                .Child(collectionName)
                .OnceAsync<T>();
        }

        public async Task<T> Set<T>(string collectionName, string key, T record)
        {
            var client = GetClient();

            await client
                .Child(collectionName)
                .Child(key)
                .PutAsync(record);

            return record;
        }
    }
}
