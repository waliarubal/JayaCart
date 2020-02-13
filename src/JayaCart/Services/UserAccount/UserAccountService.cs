using JayaCart.Models;

namespace JayaCart.Services.UserAccount
{
    public class UserAccountService: IUserAccountService
    {
        public UserAccountModel GetLoggedInAccount()
        {
            return new UserAccountModel
            {
                FullName = "Rubal Walia",
                PhoneNumber = "9928893416"
            };
        }
    }
}
