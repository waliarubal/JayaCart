using System.Threading.Tasks;
using JayaCart.Models;
using JayaCart.Services.Settings;

namespace JayaCart.Services.UserAccount
{
    public class UserAccountService: IUserAccountService
    {
        readonly ISettingsService _settingsService;

        public UserAccountService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
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
            // dummy account
            var account = new UserAccountModel
            {
                FullName = "User Full Name",
                PhoneNumber = phone
            };

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
    }
}
