using JayaCart.Model;

namespace JayaCart.Services
{
    public sealed class UserAccountService
    {
        public UserAccountModel GetSavedAccount()
        {
            return new UserAccountModel
            {
                FullName = "Rubal Walia",
                PhoneNumber = "9928893416"
            };
        }
    }
}
