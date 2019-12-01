using System;
using Org.BouncyCastle.Math;

namespace PlainRSA
{
    class Experiment1
    {
        /*
        static void Main(string[] args)
        {
            // encryptor / decryptod object
            RSA rsa = new RSA(2048);
            Key key = rsa.GetPublicKey();

            // generate signature
            byte[] s = new byte[32];
            new Random().NextBytes(s);
            BigInteger bigS = new BigInteger(s);

            // m = s^e (mod n)
            BigInteger m = bigS.ModPow(key.GetValue(), key.GetModulus());

            Console.WriteLine("s: " + BitConverter.ToString(bigS.ToByteArray()).Replace("-", ""));
            Console.WriteLine();
            Console.WriteLine("m: " + BitConverter.ToString(m.ToByteArray()).Replace("-", ""));

            // hold the screen
            Console.ReadKey(true);
        }
        */
    }
}
