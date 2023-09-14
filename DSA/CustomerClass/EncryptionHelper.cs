using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClass
{
    public class EncryptionHelper
    {
        #region Hash Creator
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public byte[] HashingHelper(string password, byte[] Salt)
        {

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                Salt,
                iterations,
                hashAlgorithm,
                keySize);

            return hash;
        }

        private byte[] IV =
        {
            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
        };

        #endregion

        #region CreditCard Encrypt/Decrypt
        private byte[] DeriveKeyFromPassword(string password)
        {
            var salt = Array.Empty<byte>();
            var iterations = 1000;
            var desiredKeyLength = 16;
            var hashMethod = HashAlgorithmName.SHA384;

            return Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(password),
                salt,
                iterations,
                hashMethod,
                desiredKeyLength);
        }

        public async Task<string> Decryptor(string password, byte[] CreditCardHash)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword(password);
            aes.IV = IV;

            using MemoryStream input = new(CreditCardHash);
            using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);

            using MemoryStream output = new();
            await cryptoStream.CopyToAsync(output);

            return Encoding.Unicode.GetString(output.ToArray());

        }
        public async Task<byte[]> Encryptor(string password, string EncryptedCCNum)
        {
            using Aes aes = Aes.Create();
            aes.Key = DeriveKeyFromPassword(password);
            aes.IV = IV;

            using MemoryStream output = new();
            using CryptoStream cryptoStream = new(output, aes.CreateEncryptor(),
                CryptoStreamMode.Write);

            await cryptoStream.WriteAsync(Encoding.Unicode.GetBytes(EncryptedCCNum));
            await cryptoStream.FlushFinalBlockAsync();

            return output.ToArray();
        }
        #endregion

    }
}
