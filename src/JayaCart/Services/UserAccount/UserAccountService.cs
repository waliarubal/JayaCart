using Firebase.Database;
using Firebase.Database.Query;
using JayaCart.Models;
using System.Linq;
using System.Threading.Tasks;

namespace JayaCart.Services
{
    public class UserAccountService : IUserAccountService
    {
        readonly ISettingsService _settingsService;
        readonly FirebaseClient _database;

        public UserAccountService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
            _database = new FirebaseClient("https://jaya-cart-2020.firebaseio.com/");
        }

        public async Task<UserAccount> Create(UserAccount account)
        {
            var existingAccount = await GetAccount(account.PhoneNumber);
            if (existingAccount != null)
                return default;

            await _database.Child("UserAccounts").PostAsync(account);
            return account;
        }

        public UserAccount GetLocalAccount()
        {
            if (_settingsService.IsHaving(nameof(UserAccount.PhoneNumber)))
            {
                var localAccount = new UserAccount
                {
                    PhoneNumber = _settingsService.Get<string>(nameof(UserAccount.PhoneNumber)),
                    FullName = _settingsService.Get<string>(nameof(UserAccount.FullName)),
                    Image = _settingsService.Get<string>(nameof(UserAccount.Image))
                };
                return localAccount;
            }

            return default;
        }

        public async Task<UserAccount> SignIn(string phone, string password, bool keepSignedIn)
        {
            var account = await GetAccount(phone);
            if (!account.Password.Equals(password))
                return default;

            if (keepSignedIn)
            {
                _settingsService.Set(nameof(UserAccount.PhoneNumber), account.PhoneNumber);
                _settingsService.Set(nameof(UserAccount.FullName), account.FullName);
                _settingsService.Set(nameof(UserAccount.Image), account.Image);
                await _settingsService.Save();
            }

            return account;
        }

        public async Task SignOut()
        {
            _settingsService.Delete(nameof(UserAccount.PhoneNumber));
            _settingsService.Delete(nameof(UserAccount.FullName));
            _settingsService.Delete(nameof(UserAccount.Image));
            await _settingsService.Save();
        }

        async Task<UserAccount> GetAccount(string phone)
        {
            var account = (await _database
                .Child("UserAccounts")
                .OnceAsync<UserAccount>())
                .Select(record => new UserAccount
                {
                    FullName = record.Object.FullName,
                    PhoneNumber = record.Object.PhoneNumber,
                    Image = record.Object.Image,
                    Password = record.Object.Password
                })
                .Where(record => record.PhoneNumber.Equals(phone))
                .FirstOrDefault();
            return account;
        }
    }
}
