using JayaCart.Models;
using System.Threading.Tasks;

namespace JayaCart.Services.UserAccount
{
    public interface IUserAccountService
    {
        UserAccountModel GetLocalAccount();

        Task<UserAccountModel> SignIn(string phone, string password, bool keepSignedIn);

        Task<UserAccountModel> Create(UserAccountModel account);

        Task SignOut();
    }
}
