using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Crypt
{
    public class Crypt_Class
    {
        public string code_text(string value)
        {
            string password = "BESTFORHUMANITY";
            string salt = "NEPIMSHCH";
            string hashAlgorithm = "SHA1";
            int passwordIterations = 2;
            string initialVector = "OFRna73m*aze01xY";
            int KeySize = 256;
            if (string.IsNullOrEmpty(value))
                return "";

            byte[] initialVectorBytes = Encoding.ASCII.GetBytes(initialVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(salt);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(value);

            PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes(password, saltValueBytes, hashAlgorithm, passwordIterations);

            byte[] KeyBytes = derivedPassword.GetBytes(KeySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            byte[] cipherTextBytes = null;

            using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(KeyBytes, initialVectorBytes))
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        cipherTextBytes = memStream.ToArray();
                        memStream.Close();
                        cryptoStream.Close();
                    }
                }
            }
            symmetricKey.Clear();
            return Convert.ToBase64String(cipherTextBytes);
        }

        public string de_code_text(string value)
        {          
            string password = "BESTFORHUMANITY";
            string salt = "NEPIMSHCH";
            string hashAlgorithm = "SHA1";
            int passwordIterations = 2;
            string initialVector = "OFRna73m*aze01xY";
            int KeySize = 256;
            if (string.IsNullOrEmpty(value))
                return "";

            byte[] initialVectorBytes = Encoding.ASCII.GetBytes(initialVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(salt);
            byte[] cipherTextBytes = Convert.FromBase64String(value);

            PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes(password, saltValueBytes, hashAlgorithm, passwordIterations);

            byte[] KeyBytes = derivedPassword.GetBytes(KeySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int byteCount = 0;

            using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(KeyBytes, initialVectorBytes))
            {
                using (MemoryStream memStream = new MemoryStream(cipherTextBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read))
                    {
                        byteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                        memStream.Close();
                        cryptoStream.Close();
                    }
                }
            }
            symmetricKey.Clear();
            return Encoding.UTF8.GetString(plainTextBytes, 0, byteCount);
        }
    }
}
