using System;
using System.Text;

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

            // get the plain text
            Key publicKey = rsa.GetPublicKey();
            string plainText = "Za oknem pada deszcz..";
            Console.WriteLine("\n");
            Console.WriteLine("Wiadomość: ");
            Console.WriteLine(plainText);
            Console.WriteLine("Wiadomość w bajtach: ");
            Console.WriteLine(BitConverter.ToString(Encoding.UTF8.GetBytes(plainText)).Replace("-", ""));

            // encryption
            byte[] encrypted = rsa.Encrypt(plainText, publicKey);
            Console.WriteLine("Podpis: ");
            Console.WriteLine(BitConverter.ToString(encrypted).Replace("-", ""));

            // decryption
            string decrypted = rsa.Decrypt(encrypted);
            Console.WriteLine("Wiadomość odszyfrowana: ");
            Console.WriteLine(decrypted);

            // hold the screen
            Console.ReadKey(true);
        }
    }
}
