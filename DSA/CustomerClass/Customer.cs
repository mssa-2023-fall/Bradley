using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using CustomerClassDB;

namespace CustomerClass
{
    public class Customer
    {
        private EncryptionHelper _encryptionHelper = new();
        public byte[] Salt;
        public string Name { get; }
        public string Password {  get; }
        public string Email { get; }
        public byte[] PasswordHash { get; }
        public byte[] CreditCardHash { get; }



        public Customer(string name, string email, string creditCardNumber, string password)
        {
            this.Name = name;
            this.Email = email;
            Salt = RandomNumberGenerator.GetBytes(64);

            PasswordHash = _encryptionHelper.HashingHelper(password, Salt);
            CreditCardHash = _encryptionHelper.Encryptor(password, creditCardNumber).Result;
        }
       
    }
}