using System;

namespace JayaCart.Mobile.Services
{
    public class InformationService : IInformationService
    {
        public string ApplicationName => "Jaya Cart";

        public Version ApplicationVersion => new Version(1, 0, 0, 0);
    }
}
