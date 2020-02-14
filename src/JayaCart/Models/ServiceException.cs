using System;

namespace JayaCart.Models
{
    public class ServiceException: Exception
    {
        public ServiceException(string message): base(message)
        {
            
        }
    }
}
