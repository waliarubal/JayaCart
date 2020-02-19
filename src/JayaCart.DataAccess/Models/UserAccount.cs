using JayaCart.DataAccess.Base;

namespace JayaCart.DataAccess.Models
{
    public class UserAccount: ModelBase
    {
        public UserAccount()
        {
            Image = "\uf2bd";
        }

        public UserAccount(string phone): this()
        {
            PhoneNumber = phone;
        }

        public string PhoneNumber
        {
            get => Get<string>();
            set => Set(value);
        }

        public string FirstName
        {
            get => Get<string>();
            set => Set(value);
        }

        public string LastName
        {
            get => Get<string>();
            set => Set(value);
        }

        public string AddressLine1
        {
            get => Get<string>();
            set => Set(value);
        }

        public string AddressLine2
        {
            get => Get<string>();
            set => Set(value);
        }

        public string City
        {
            get => Get<string>();
            set => Set(value);
        }

        public string Password
        {
            get => Get<string>();
            set => Set(value);
        }

        public string Image
        {
            get => Get<string>();
            set => Set(value);
        }

        public float Balance
        {
            get => Get<float>();
            set => Set(value);
        }
    }
}
