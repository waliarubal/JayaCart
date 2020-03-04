using JayaCart.DataAccess.Base;
using JayaCart.DataAccess.Models;
using System;
using System.Threading.Tasks;

namespace JayaCart.DataAccess.Services
{
    public class UserAccountService : ModelBase, IUserAccountService
    {
        readonly ISettingsService _settingsService;
        readonly IDatabaseService _databaseService;

        public UserAccountService(ISettingsService settingsService, IDatabaseService databaseService)
        {
            _settingsService = settingsService;
            _databaseService = databaseService;
        }

        async Task<ApiResponse<UserAccount>> GetAccount(string phoneNumber)
        {
            return await _databaseService.Get<UserAccount>("UserAccounts", phoneNumber);
        }

        public UserAccount GetLocalAccount()
        {
            if (_settingsService.IsHaving(nameof(UserAccount.PhoneNumber)))
            {
                var localAccount = new UserAccount(_settingsService.Get<string>(nameof(UserAccount.PhoneNumber)))
                {
                    FirstName = _settingsService.Get<string>(nameof(UserAccount.FirstName)),
                    Image = _settingsService.Get<string>(nameof(UserAccount.Image)),
                    City = _settingsService.Get<string>(nameof(UserAccount.City))
                };
                return localAccount;
            }

            return default;
        }

        public async Task<UserAccount> Create(UserAccount account)
        {
            var response = await GetAccount(account.PhoneNumber);
            if (response != null && !response.IsHavingError && response.Response != null)
                throw new ServiceException($"Another user with phone number {account.PhoneNumber} is registered.");

            account.Password = account.Password.MD5();

            response = await _databaseService.Insert("UserAccounts", account.PhoneNumber, account);
            if (response == null)
                throw new ServiceException($"Failed to create user account with phone number {account.PhoneNumber}");
            else if (response.IsHavingError)
                throw new ServiceException(response.Error);

            _settingsService.Set(nameof(UserAccount.PhoneNumber), account.PhoneNumber);
            _settingsService.Set(nameof(UserAccount.FirstName), account.FirstName);
            _settingsService.Set(nameof(UserAccount.City), account.City);
            _settingsService.Set(nameof(UserAccount.Image), account.Image);
            await _settingsService.Save();

            return account;
        }

        public async Task<UserAccount> SignIn(string phone, string password)
        {
            var response = await GetAccount(phone);
            if (response == null)
                throw new ServiceException($"User with phone number {phone} is not registered.");
            if (response.IsHavingError)
                throw new ServiceException(response.Error);

            if (!response.Response.Password.Equals(password.MD5(), StringComparison.Ordinal))
                throw new ServiceException("Password is incorrect.");

            _settingsService.Set(nameof(UserAccount.PhoneNumber), response.Response.PhoneNumber);
            _settingsService.Set(nameof(UserAccount.FirstName), response.Response.FirstName);
            _settingsService.Set(nameof(UserAccount.City), response.Response.City);
            _settingsService.Set(nameof(UserAccount.Image), response.Response.Image);
            await _settingsService.Save();

            return response.Response;
        }

        public async Task SignOut()
        {
            _settingsService.Delete(nameof(UserAccount.PhoneNumber));
            _settingsService.Delete(nameof(UserAccount.FirstName));
            _settingsService.Delete(nameof(UserAccount.City));
            _settingsService.Delete(nameof(UserAccount.Image));
            await _settingsService.Save();
        }
    }
}
