using System;
using Org.BouncyCastle.Math;

namespace PlainRSA
{
    public class Experiment1
    {
        private readonly RSA rsa;
        private readonly Key key;

        public Experiment1()
        {
            // encryptor / decryptod object
            rsa = new RSA(2048);
            key = rsa.GetPublicKey();
        }

        public void Start()
        {
            // generate signature
            BigInteger s = new BigInteger(32, new Random());

            // m = s^e (mod n)
            BigInteger m = s.ModPow(key.GetValue(), key.GetModulus());

            Console.WriteLine("Eksperyment 1:\n");
            Console.WriteLine($"s: {s.ToString()}\n");
            Console.WriteLine($"m: {m.ToString()}");
        }
    }
}
