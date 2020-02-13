using JayaCart.Models;
using System.Threading.Tasks;

namespace JayaCart.Services
{
    public interface IUserAccountService
    {
        UserAccount GetLocalAccount();

        Task<UserAccount> SignIn(string phone, string password, bool keepSignedIn);

        Task<UserAccount> Create(UserAccount account);

        Task SignOut();
    }
}
