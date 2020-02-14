using JayaCart.Models;
using JayaCart.Shared.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JayaCart.Services
{
    public class UserAccountService : IUserAccountService
    {
        readonly ISettingsService _settingsService;
        readonly IDatabaseService _databaseService;

        public UserAccountService(ISettingsService settingsService, IDatabaseService databaseService)
        {
            _settingsService = settingsService;
            _databaseService = databaseService;
        }

        async Task<UserAccount> GetAccount(string phoneNumber)
        {
            var account = (await _databaseService.GetMany<UserAccount>("UserAccounts"))
                .Select(record => new UserAccount
                {
                    FullName = record.Object.FullName,
                    PhoneNumber = record.Object.PhoneNumber,
                    Image = record.Object.Image,
                    Password = record.Object.Password
                })
                .Where(record => record.PhoneNumber.Equals(phoneNumber))
                .FirstOrDefault();
            return account;
        }

        public async Task<UserAccount> Create(UserAccount account)
        {
            var existingAccount = await GetAccount(account.PhoneNumber);
            if (existingAccount != null)
                throw new InvalidOperationException($"Another user with phone number {account.PhoneNumber} is already registered.");

            await _databaseService.Set("UserAccounts", account);
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
                throw new InvalidOperationException("Failed to sign in, phone number and passowrd combination is incorrect.");

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
    }
}
