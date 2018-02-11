using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace REST_API.Utilities
{
    public static class HashUtility
    {
        private static int saltSize = 16;
        private static int hashSize = 48;

        public static string HashPassword(string password)
        {
            byte[] salt = new byte[saltSize];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = new byte[hashSize];
            using (Rfc2898DeriveBytes alg = new Rfc2898DeriveBytes(password,salt,10000))
            {
                hash = alg.GetBytes(hashSize);
            }

            byte[] result = new byte[saltSize + hashSize];

            Array.Copy(salt, 0, result, 0, saltSize);
            Array.Copy(hash, 0, result, saltSize, hashSize);

            return Convert.ToBase64String(result);
        }

        public static bool VerifyPassword(string passwordHash,string password)
        {
            byte[] hashResult = Convert.FromBase64String(passwordHash);

            byte[] salt = new byte[saltSize];
            Array.Copy(hashResult, 0, salt, 0, saltSize);

            byte[] hash = new byte[hashSize];
            using (Rfc2898DeriveBytes alg = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                hash = alg.GetBytes(hashSize);
            }

            for (int i = 0; i < hashSize; i++)
            {
                if(hashResult[i + saltSize] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}