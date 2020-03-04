using System;
using Newtonsoft.Json;

namespace JayaCart.DataAccess.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiResponse<T> where T : new()
    {
        [JsonConstructor]
        public ApiResponse()
        {

        }

        public ApiResponse(T response, string error = null) : this()
        {
            Error = error;
            Response = response;
            IsHavingError = error != null;
        }

        [JsonProperty]
        public bool IsHavingError { get; set; }

        [JsonProperty]
        public string Error { get; set; }

        [JsonProperty]
        public T Response { get; set; }
    }
}
