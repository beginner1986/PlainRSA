using System;

namespace PlainRSA
{
    class Program
    {
        static void Main(string[] args)
        {
            RSA rsa = new RSA(2048);
            Key publicKey = rsa.GetPublicKey();
            string plainText = "Wiadomość do zaszyfrowania";
            //byte[] encrypted = rsa.Encrypt(plainText, publicKey);
            //string decrypted = rsa.Decrypt(encrypted);

            Console.ReadKey(true);


        }
    }
}
