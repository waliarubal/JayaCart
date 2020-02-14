using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JayaCart.Shared
{
    public static class Extensions
    {
        public static string MD5(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return default;

            var bytes = Encoding.ASCII.GetBytes(value);

            byte[] md5Bytes;
            using (var md5 = new MD5CryptoServiceProvider())
            {
                md5Bytes = md5.ComputeHash(bytes);
            }

            var md5String = Encoding.ASCII.GetString(md5Bytes);
            return md5String;
        }
    }
}
