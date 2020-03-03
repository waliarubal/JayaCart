using System;

namespace JayaCart.DataAccess.Models
{
    public class ServiceException: Exception
    {
        public ServiceException(string message): base(message)
        {
            
        }
    }
}
