using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class AESEncryption
    {
        public static string EncryptQueryParam(string value, string key, string iv)
        {


            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(key);
                aesAlg.IV = Convert.FromBase64String(iv);

                var encryptor = aesAlg.CreateEncryptor();
                byte[] encryptedBytes;

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(value);
                        }
                        encryptedBytes = msEncrypt.ToArray();
                    }
                }

                string encryptedValue = Convert.ToBase64String(encryptedBytes);
                return encryptedValue;
            }
        }

        public static string Decrypt(string encryptedData, string key, string iv)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(key);
                aesAlg.IV = Convert.FromBase64String(iv);

                var decryptor = aesAlg.CreateDecryptor();
                var encryptedBytes = Convert.FromBase64String(encryptedData);

                string decryptedData;

                using (var msDecrypt = new MemoryStream(encryptedBytes))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            decryptedData = srDecrypt.ReadToEnd();
                        }
                    }
                }

                return decryptedData;
            }
        }

        public static string GenerateKey()
        {
            using (Aes aesAlgorithm = Aes.Create())
            {
                aesAlgorithm.KeySize = 256;
                aesAlgorithm.GenerateKey();
                return Convert.ToBase64String(aesAlgorithm.Key);
            }
        }
        public static string GenerateIV()
        {
            using (var aes = Aes.Create())
            {
                aes.GenerateIV();
                return Convert.ToBase64String(aes.IV);
            }
        }
    }

}

