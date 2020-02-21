using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace JayaCart.DataAccess.Services
{
    public class DatabaseService : IDatabaseService
    {
        const string DATABASE_URL = "https://jaya-cart-1988.firebaseio.com/";

        FirebaseClient GetClient()
        {
            var client = new FirebaseClient(DATABASE_URL);
            return client;
        }

        public async Task<T> Get<T>(string resourceName, string key)
        {
            var client = GetClient();

            T result;
            try
            {
                result = await client
                .Child(resourceName)
                .Child(key)
                .OnceSingleAsync<T>();
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                result = default;
            }

            return result;

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
