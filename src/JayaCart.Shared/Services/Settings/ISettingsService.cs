﻿using System.Threading.Tasks;

namespace JayaCart.Mobile.Shared.Services
{
    public interface ISettingsService
    {
        Task Save();

        T Get<T>(string name);

        void Set<T>(string name, T value);

        bool Delete(string name);

        bool IsHaving(string name);
    }
}
