using System;

namespace JayaCart.Mobile.Services
{
    public interface IInformationService
    {
        string ApplicationName { get; }

        Version ApplicationVersion { get; }
    }
}
