using System;
using System.Text;
using System.Diagnostics;

namespace PlainRSA
{
    class Program
    {
        /*
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
            Stopwatch timer = new Stopwatch();
            timer.Start();
            byte[] encrypted = rsa.Encrypt(plainText, publicKey);
            timer.Stop();
            TimeSpan encryptionTime = timer.Elapsed;
            timer.Reset();

            Console.WriteLine("Podpis: ");
            Console.WriteLine(BitConverter.ToString(encrypted).Replace("-", ""));

            // decryption
            timer.Start();
            string decrypted = rsa.Decrypt(encrypted);
            timer.Stop();
            TimeSpan decryptionTime = timer.Elapsed;
            //Console.WriteLine("Wiadomość odszyfrowana: ");
            //Console.WriteLine(decrypted);

            // signature verification
            Console.Write("Weryfikacja: ");
            if (plainText.Equals(decrypted))
                Console.WriteLine("podpis się zgadza");
            else
                Console.WriteLine("podpis niezgodny");
            Console.WriteLine();

            // time measurement presentation
            Console.WriteLine("Czas podpisywania: {0}", encryptionTime);
            Console.WriteLine("Czas weryfikacji podpisu: {0}", decryptionTime);

            // hold the screen
            Console.ReadKey(true);
        }
        */
    }
}
