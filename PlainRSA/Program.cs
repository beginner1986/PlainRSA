using System;

namespace PlainRSA
{
    class Program
    {
        static void Main(string[] args)
        {
            // introduction
            Console.WriteLine("Kryptologia: Laboratorium nr 3 - Badanie RSA.");
            Console.WriteLine("Adam Emieljaniuk - N2C\n");

            // RSA encryptor / decryptor class
            RSA rsa = new RSA(2048);

            // print the hidden cipher data, unavailable outside the RSA class
            rsa.ShowMySecrets();

            // example of usage
            Key publicKey = rsa.GetPublicKey();
            string plainText = "Wiadomość do zaszyfrowania";
            //byte[] encrypted = rsa.Encrypt(plainText, publicKey);
            //string decrypted = rsa.Decrypt(encrypted);

            Console.ReadKey(true);
        }
    }
}
