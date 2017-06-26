using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace PasswordManagerProject.Interface
{
    public class PasswordCrypt
    {
        // Member variables
        private string masterPassword = "";
        private Rfc2898DeriveBytes passwordKey = null;
        private TripleDES encAlgorithm = null;
        private TripleDES decAlgorithm = null;

        // Default parameters that are used to generate the key.
        private byte[] salt = new byte[8];
        private int iterations = 1;

        // Constructor that takes the master password as an argument.
        public PasswordCrypt(string masterPass)
        {
            masterPassword = masterPass;
            // Generate the symmetric key from the masterPassword.
            passwordKey = deriveKey(masterPassword);
            // Create the TripleDES encryption aglorithm object.
            encAlgorithm = TripleDES.Create();
            // Store the derived key into the algorithm object.
            encAlgorithm.Key = passwordKey.GetBytes(16);
            encAlgorithm.Mode = CipherMode.ECB;

        }

        // Generate the key based off of the masterPassword.
        private Rfc2898DeriveBytes deriveKey(string masterPassword)
        {
            return new Rfc2898DeriveBytes(masterPassword, salt, iterations);
        }

        // Encrypt the password given and return it in a byte array.
        public string encryptPassword(string password)
        {
            // Create the encryption stream so that the TripleDES algorithm will use.
            MemoryStream encryptionStream = new MemoryStream();
            CryptoStream encrypt = new CryptoStream(encryptionStream, encAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);

            // Create buffer with UTF encoding.
            byte[] utfSecret = Encoding.Unicode.GetBytes(password);

            // Encrypt the data in the stream and write to the utfSecret buffer.
            encrypt.Write(utfSecret, 0, utfSecret.Length);
            encrypt.FlushFinalBlock();
            encrypt.Close();




            // Extract the encrypted message from the stream and store it in to the buffer.
            byte[] encryptedMessage = encryptionStream.ToArray();

            // Reset the state of operations.
            passwordKey.Reset();

            return Convert.ToBase64String(encryptedMessage);
        }

        // Decrypt the password and return it as a string.
        public string decryptPassword(string encryptedPass)
        {
            // Create the TripleDES decryption aglorithm object.
            decAlgorithm = TripleDES.Create();
            decAlgorithm.Key = encAlgorithm.Key;
            decAlgorithm.Mode = CipherMode.ECB;

            byte[] plaintextBytes = Convert.FromBase64String(encryptedPass);
            // Assign the params used in the en                                         cryption algorithm to the decryption object.

            // Create the decryption stream the TripleDES algorithm will use.
            MemoryStream decryptStream = new MemoryStream();
            CryptoStream decrypt = new CryptoStream(decryptStream, decAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
            // Iterate over the encrypted password and decrypt it.
            decrypt.Write(plaintextBytes, 0, plaintextBytes.Length);
            decrypt.Flush();
            decrypt.Close();

            // Extract the message from the stream.
            string decryptedMessage = Encoding.Unicode.GetString(decryptStream.ToArray());

            // Reset the state of operations of the key.
            passwordKey.Reset();

            return decryptedMessage;
        }
    }
}