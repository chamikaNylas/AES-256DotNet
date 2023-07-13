// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

string key = AESEncryption.GenerateKey();
string iv = AESEncryption.GenerateIV();

Console.WriteLine("Generated Key:");
Console.WriteLine(key);
Console.WriteLine("Generated IV:");
Console.WriteLine(iv);
var today=DateTime.Now;
//asif.log@gmail.com,898971,809,{today.ToString()--->User Email, Organization External Id, Client Id,Issued Date
string value = $"asif.log@gmail.com,898971,809,{today.ToString()}";
string encryptedValue = AESEncryption.EncryptQueryParam(value, key, iv);
Console.WriteLine("Encrypted Value:");
Console.WriteLine(encryptedValue);

string decryptedValue = AESEncryption.Decrypt(encryptedValue, key, iv);
Console.WriteLine("Decrypted Value:");
Console.WriteLine(decryptedValue);
//using System;
//using System.IO;
//using System.Security.Cryptography;

//namespace AesEncryption
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Welcome to the Aes Encryption Test tool");
//            Console.WriteLine("Provide the Aes Key in base64 format :");
//            string keyBase64 = Console.ReadLine();
//            Console.WriteLine("--------------------------------------------------------------");
//            Console.WriteLine("Please enter the text that you want to encrypt:");
//            string plainText = Console.ReadLine();
//            Console.WriteLine("--------------------------------------------------------------");
//            string cipherText = EncryptDataWithAes(plainText, keyBase64, out string vectorBase64);

//            Console.WriteLine("--------------------------------------------------------------");
//            Console.WriteLine("Here is the cipher text:");
//            Console.WriteLine(cipherText);

//            Console.WriteLine("--------------------------------------------------------------");
//            Console.WriteLine("Here is the Aes IV in Base64:");
//            Console.WriteLine(vectorBase64);
//        }

//        private static string EncryptDataWithAes(string plainText, string keyBase64, out string vectorBase64)
//        {
//            using (Aes aesAlgorithm = Aes.Create())
//            {
//                aesAlgorithm.Key = Convert.FromBase64String(keyBase64);
//                aesAlgorithm.GenerateIV();
//                Console.WriteLine($"Aes Cipher Mode : {aesAlgorithm.Mode}");
//                Console.WriteLine($"Aes Padding Mode: {aesAlgorithm.Padding}");
//                Console.WriteLine($"Aes Key Size : {aesAlgorithm.KeySize}");

//                //set the parameters with out keyword
//                vectorBase64 = Convert.ToBase64String(aesAlgorithm.IV);

//                // Create encryptor object
//                ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor();

//                byte[] encryptedData;

//                //Encryption will be done in a memory stream through a CryptoStream object
//                using (MemoryStream ms = new MemoryStream())
//                {
//                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
//                    {
//                        using (StreamWriter sw = new StreamWriter(cs))
//                        {
//                            sw.Write(plainText);
//                        }
//                        encryptedData = ms.ToArray();
//                    }
//                }

//                return Convert.ToBase64String(encryptedData);
//            }
//        }
//    }
//}

