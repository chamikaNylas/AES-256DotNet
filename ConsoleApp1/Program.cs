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


