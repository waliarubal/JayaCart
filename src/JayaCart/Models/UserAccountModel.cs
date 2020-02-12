using JayaCart.Shared.Base;

namespace JayaCart.Models
{
    public class UserAccountModel: ModelBase
    {
        public UserAccountModel()
        {
            Image = "\uf2bd";
        }

        public string FullName
        {
            get => Get<string>();
            set => Set(value);
        }

        public string PhoneNumber
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
