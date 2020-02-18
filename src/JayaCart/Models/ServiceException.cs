using System;

namespace JayaCart.Mobile.Models
{
    public class ServiceException: Exception
    {
        public ServiceException(string message): base(message)
        {
            
        }
    }
}
