using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Security;
using System.Text;
namespace GroupProject
{
    public class HashPass
    {
        public static string Saltmethod()
        {
            var salting = new byte[15];
            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(salting);
            }
            return Convert.ToBase64String(salting);


        }
        public static string hashed(string input, string salting)
        {
            using (SHA1Managed num = new SHA1Managed())
            {
                var hashed = num.ComputeHash(Encoding.UTF8.GetBytes(input + salting));
                var sbuilder = new StringBuilder(hashed.Length * 2);
                foreach (byte b in hashed)
                {
                    sbuilder.Append(b.ToString("x2"));
                }
                return sbuilder.ToString();
            }
        }
    }
}