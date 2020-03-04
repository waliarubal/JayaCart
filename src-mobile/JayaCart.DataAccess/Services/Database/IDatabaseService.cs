using JayaCart.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JayaCart.DataAccess.Services
{
    public interface IDatabaseService
    {
        Task<ApiResponse<T>> Get<T>(string collectionName, string key) where T : new();

        Task<ApiResponse<List<T>>> GetMany<T>(string collectionName) where T : new();

        Task<ApiResponse<T>> Insert<T>(string collectionName, string key, T record) where T : new();
    }
}
