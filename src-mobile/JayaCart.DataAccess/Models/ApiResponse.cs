using Newtonsoft.Json;

namespace JayaCart.DataAccess.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    class ApiResponse<T> where T : new()
    {
        [JsonProperty]
        public bool IsHavingError { get; set; }

        [JsonProperty]
        public string Error { get; set; }

        [JsonProperty]
        public T Response { get; set; }
    }
}
