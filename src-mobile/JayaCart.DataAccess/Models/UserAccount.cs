using JayaCart.DataAccess.Base;
using Newtonsoft.Json;

namespace JayaCart.DataAccess.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UserAccount: ModelBase
    {
        [JsonConstructor]
        public UserAccount()
        {
            Image = "\uf2bd";
        }

        public UserAccount(string phone): this()
        {
            PhoneNumber = phone;
        }

        [JsonProperty]
        public string PhoneNumber
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public string FirstName
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public string LastName
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public string AddressLine1
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public string AddressLine2
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public string City
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public string Password
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public string Image
        {
            get => Get<string>();
            set => Set(value);
        }

        [JsonProperty]
        public float Balance
        {
            get => Get<float>();
            set => Set(value);
        }
    }
}
