using System;
using System.Text;
using System.Diagnostics;
using Org.BouncyCastle.Math;

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
            BigInteger plainText = new BigInteger(Encoding.UTF8.GetBytes("Za oknem pada deszcz.."));
            Console.WriteLine("\n");
            Console.WriteLine("Wiadomość: ");
            Console.WriteLine(Encoding.UTF8.GetString(plainText.ToByteArray()));

            // encryption
            Stopwatch timer = new Stopwatch();
            timer.Start();
            BigInteger encrypted = rsa.Encrypt(plainText, publicKey);
            timer.Stop();
            TimeSpan encryptionTime = timer.Elapsed;
            timer.Reset();

            Console.WriteLine("Podpis: ");
            Console.WriteLine(encrypted.ToString());

            // decryption
            timer.Start();
            BigInteger decrypted = rsa.Decrypt(encrypted);
            timer.Stop();
            TimeSpan decryptionTime = timer.Elapsed;

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

            // experiment 1
            Console.WriteLine("----------------------------------------------------\n");
            Experiment1 experiment1 = new Experiment1();
            experiment1.Start();

            // experiment 2
            Console.WriteLine("----------------------------------------------------\n");
            Experiment2 experiment2 = new Experiment2();
            experiment2.Start();

            // hold the screen
            Console.ReadKey(true);
        }
    }
}
