using JayaCart.DataAccess.Base;

namespace JayaCart.DataAccess.Models
{
    public class UserAccount: ModelBase
    {
        public UserAccount()
        {
            Image = "\uf2bd";
        }

        public UserAccount(string phone, string name): this()
        {
            PhoneNumber = phone;
            FullName = name;
        }

        public string PhoneNumber
        {
            get => Get<string>();
            set => Set(value);
        }

        public string FullName
        {
            get => Get<string>();
            set => Set(value);
        }

        public string Address
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
    }
}
