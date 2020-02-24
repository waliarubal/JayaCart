using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace JayaCart.DataAccess.Services
{
    public class DatabaseService : IDatabaseService
    {
        const string API_URL = "https://jaya-cart-1988.firebaseapp.com/api/v1";

        RestClient GetClient(string resource, Method method, out RestRequest request)
        {
            var settings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Include,
                TypeNameHandling = TypeNameHandling.None,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.None,
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            };

            var client = new RestClient(API_URL);
            client.UseNewtonsoftJson(settings);

            request = new RestRequest(resource, method, DataFormat.Json)
            {
                JsonSerializer = new JsonNetSerializer(settings)
            };

            return client;
        }

        public async Task<T> Get<T>(string collectionName, string key) where T : new()
        {
            var client = GetClient($"{collectionName}/{key}", Method.GET, out RestRequest request);

            T result;
            try
            {
                result = await client.GetAsync<T>(request);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                result = default;
            }

            return result;
        }

        public async Task<IReadOnlyCollection<T>> GetMany<T>(string collectionName) where T : new()
        {
            var client = GetClient($"{collectionName}", Method.GET, out RestRequest request);

            IReadOnlyCollection<T> result;
            try
            {
                result = await client.GetAsync<List<T>>(request);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                result = default;
            }

            return result;
        }

        public async Task<T> Insert<T>(string collectionName, string key, T record) where T : new()
        {
            var client = GetClient($"{collectionName}", Method.POST, out RestRequest request);
            request.OnBeforeDeserialization = response => response.ContentType = "application/json";
            request.AddJsonBody(record);

            T result;
            try
            {
                result = await client.PostAsync<T>(request);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                result = default;
            }

            return result;
        }
    }
}
