

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain
{
    public class Wallet
    {
        public static string _privateKey;
        public static string _publicKey;
        private static UnicodeEncoding _encoder = new UnicodeEncoding();




        public Wallet()
        {
            var rsa = new RSACryptoServiceProvider();
            _privateKey = rsa.ToXmlString(true);
            _publicKey = rsa.ToXmlString(false);

        }

        public void generatedKeyPair()
        {
            try
            {
                KeyPairGenerator keyGen = KeyPairGenerator.getInstance("ECDSA", "BC");
                SecureRandom random = SecureRandom.getInstance("SHA1PRNG");
                ECGenParameterSpec ecSpec = new ECGenParameterSpec("prime192v1");
                // Initialize the key generator and generate a KeyPair
                keyGen.initialize(ecSpec, random);   //256 bytes provides an acceptable security level
                KeyPair keyPair = keyGen.generateKeyPair();
                // Set the public and private keys from the keyPair
                privateKey = keyPair.getPrivate();
                publicKey = keyPair.getPublic();
            }




        }

        public string Decrypt(string data)
        {
            var rsa = new RSACryptoServiceProvider();
            var dataArray = data.Split(new char[] { ',' });
            byte[] dataByte = new byte[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                dataByte[i] = Convert.ToByte(dataArray[i]);
            }

            rsa.FromXmlString(_privateKey);
            var decryptedByte = rsa.Decrypt(dataByte, false);
            return _encoder.GetString(decryptedByte);
        }

        public string Encrypt(string data)
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(_publicKey);
            var dataToEncrypt = _encoder.GetBytes(data);
            var encryptedByteArray = rsa.Encrypt(dataToEncrypt, false).ToArray();
            var length = encryptedByteArray.Count();
            var item = 0;
            var sb = new StringBuilder();
            foreach (var x in encryptedByteArray)
            {
                item++;
                sb.Append(x);

                if (item < length)
                    sb.Append(",");
            }

            return sb.ToString();
        }
    }
}