// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

string key ="SHARED_KEY";
string iv ="INITIALIZATION_VECTOR";
var today=DateTime.UtcNow;
var serrionData = new SessionRequest()
{
    Email = "asif.log@gmail.com",
    OfficeReferenceId = "898971",
    ClientId = "4509",
    IssuedDate = today,
};
string value = JsonConvert.SerializeObject(serrionData);
string encryptedValue = AESEncryption.EncryptQueryParam(value, key, iv);
Console.WriteLine("Encrypted Value:");
Console.WriteLine(encryptedValue);

string decryptedValue = AESEncryption.Decrypt(encryptedValue, key, iv);
Console.WriteLine("Decrypted Value:");
Console.WriteLine(decryptedValue);


