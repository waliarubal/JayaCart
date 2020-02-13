using System.Threading.Tasks;

namespace JayaCart.Services.Settings
{
    public interface ISettingsService
    {
        Task Save();

        T Get<T>(string name);

        void Set<T>(string name, T value);

        bool Delete(string name);
    }
}
