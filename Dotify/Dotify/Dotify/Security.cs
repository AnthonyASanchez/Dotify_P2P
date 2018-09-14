using System;
using System.Security.Cryptography;
//This class is use for hashing user information
namespace Dotify
{
    public class Security
    {
        public Security()
        {
            
        }

        public static String Hash(String password){
            using (var sha = SHA512.Create())
            {
                return Convert.ToBase64String(sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}
