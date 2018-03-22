using System;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain
{

    public class Hash
    {
        public static string GetHashSha256(string text)
        // TAKES A STRING AND APPLIES SHA256 TO IT
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text); //NOT Encoding.Unicsode.GetBytes...
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}