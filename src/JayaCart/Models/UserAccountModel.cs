using JayaCart.Shared.Base;

namespace JayaCart.Models
{
    public class UserAccountModel: ModelBase
    {
        public UserAccountModel()
        {
            Image = "\uf2bd";
        }

        public UserAccountModel(string phone, string name): this()
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
