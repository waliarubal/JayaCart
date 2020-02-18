using JayaCart.Mobile.Models;
using JayaCart.Mobile.Shared;
using JayaCart.Mobile.Shared.Services;
using System;
using System.Threading.Tasks;

namespace JayaCart.Mobile.Services
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
            var account = await _databaseService.Get<UserAccount>("UserAccounts", phoneNumber);
            return account;
        }

        public async Task<UserAccount> Create(UserAccount account)
        {            
            var existingAccount = await GetAccount(account.PhoneNumber);
            if (existingAccount != null)
                throw new ServiceException($"Another user with phone number {account.PhoneNumber} is registered.");

            account.Password = account.Password.MD5();

            var newAccount = await _databaseService.Set("UserAccounts", account.PhoneNumber, account);
            if (newAccount == null)
                throw new ServiceException($"Failed to create user account with phone number {account.PhoneNumber}");

            _settingsService.Set(nameof(UserAccount.PhoneNumber), account.PhoneNumber);
            _settingsService.Set(nameof(UserAccount.FullName), account.FullName);
            _settingsService.Set(nameof(UserAccount.Address), account.Address);
            _settingsService.Set(nameof(UserAccount.Image), account.Image);
            await _settingsService.Save();

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
            if (account == null)
                throw new ServiceException($"User with phone number {phone} is not registered.");

            var passwordHash = password.MD5();
            if (!account.Password.Equals(passwordHash, StringComparison.Ordinal))
                throw new ServiceException("Password is incorrect.");

            if (keepSignedIn)
            {
                _settingsService.Set(nameof(UserAccount.PhoneNumber), account.PhoneNumber);
                _settingsService.Set(nameof(UserAccount.FullName), account.FullName);
                _settingsService.Set(nameof(UserAccount.Address), account.Address);
                _settingsService.Set(nameof(UserAccount.Image), account.Image);
                await _settingsService.Save();
            }

            return account;
        }

        public async Task SignOut()
        {
            _settingsService.Delete(nameof(UserAccount.PhoneNumber));
            _settingsService.Delete(nameof(UserAccount.FullName));
            _settingsService.Delete(nameof(UserAccount.Address));
            _settingsService.Delete(nameof(UserAccount.Image));
            await _settingsService.Save();
        }
    }
}
