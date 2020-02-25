using JayaCart.DataAccess.Models;
using System.Threading.Tasks;

namespace JayaCart.DataAccess.Services
{
    public interface IUserAccountService
    {
        Task<UserAccount> SignIn(string phone, string password);

        Task<UserAccount> Create(UserAccount account);

        Task SignOut();

        UserAccount GetLocalAccount();
    }
}
