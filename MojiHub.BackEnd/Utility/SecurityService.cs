

using System.Security.Cryptography;
using System.Text;

namespace MojiHub.BackEnd.Utility
{
    public static class SecurityService
    {
        public static string HashPassword(string password)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)   
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(password);
            encodedBytes = md5.ComputeHash(originalBytes);
            //Convert encoded bytes back to a 'readable' string   
            return BitConverter.ToString(encodedBytes);
        }
        public static bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            // Verify the input password against the hashed password
            string t=HashPassword(inputPassword);
            if(hashedPassword == t)
            {
                return true;    
            }


            return false;
        }

    }
}
