using JayaCart.Models;
using System.Threading.Tasks;

namespace JayaCart.Services.UserAccount
{
    public interface IUserAccountService
    {
        UserAccountModel GetSignedInAccount();

        Task<UserAccountModel> SignIn(string phone, string password);

        Task SignOut();
    }
}
