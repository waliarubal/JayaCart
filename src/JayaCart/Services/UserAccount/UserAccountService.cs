using Firebase.Database;
using Firebase.Database.Query;
using JayaCart.Models;
using JayaCart.Services.Settings;
using System.Linq;
using System.Threading.Tasks;

namespace JayaCart.Services.UserAccount
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

        public async Task<UserAccountModel> Create(UserAccountModel account)
        {
            var existingAccount = await GetAccount(account.PhoneNumber);
            if (existingAccount != null)
                return default;

            await _database.Child("UserAccounts").PostAsync(account);
            return account;
        }

        public UserAccountModel GetLocalAccount()
        {
            if (_settingsService.IsHaving(nameof(UserAccountModel.PhoneNumber)))
            {
                var localAccount = new UserAccountModel
                {
                    PhoneNumber = _settingsService.Get<string>(nameof(UserAccountModel.PhoneNumber)),
                    FullName = _settingsService.Get<string>(nameof(UserAccountModel.FullName)),
                    Image = _settingsService.Get<string>(nameof(UserAccountModel.Image))
                };
                return localAccount;
            }

            return default;
        }

        public async Task<UserAccountModel> SignIn(string phone, string password, bool keepSignedIn)
        {
            var account = await GetAccount(phone);
            if (!account.Password.Equals(password))
                return default;

            if (keepSignedIn)
            {
                _settingsService.Set(nameof(UserAccountModel.PhoneNumber), account.PhoneNumber);
                _settingsService.Set(nameof(UserAccountModel.FullName), account.FullName);
                _settingsService.Set(nameof(UserAccountModel.Image), account.Image);
                await _settingsService.Save();
            }

            return account;
        }

        public async Task SignOut()
        {
            _settingsService.Delete(nameof(UserAccountModel.PhoneNumber));
            _settingsService.Delete(nameof(UserAccountModel.FullName));
            _settingsService.Delete(nameof(UserAccountModel.Image));
            await _settingsService.Save();
        }

        async Task<UserAccountModel> GetAccount(string phone)
        {
            var account = (await _database
                .Child("UserAccounts")
                .OnceAsync<UserAccountModel>())
                .Select(record => new UserAccountModel
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
