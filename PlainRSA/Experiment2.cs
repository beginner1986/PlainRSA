using System;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

namespace PlainRSA
{
    public class Experiment2
    {
        private readonly RSA rsa;
        private readonly Key key;
        private readonly int messageSize = 8;

        public Experiment2()
        {
            rsa = new RSA(2048);
            key = rsa.GetPublicKey();
        }

        public void Start()
        {
            // encryptor / decryptor object

            BigInteger m1 = new BigInteger(messageSize, new Random());
            BigInteger m2 = new BigInteger(messageSize, new Random());
            BigInteger m = m1.Multiply(m2).Mod(key.GetModulus());

            BigInteger s1 = rsa.Encrypt(m1, key);
            BigInteger s2 = rsa.Encrypt(m2, key);
            BigInteger fakeS = s1.Multiply(s2).Mod(key.GetModulus());

            BigInteger originalS = rsa.Encrypt(m, key);

            Console.WriteLine("Eksperyment 2:\n");
            Console.WriteLine($"fake s: {fakeS}\n");
            Console.WriteLine($"original s: {originalS}\n");
        }
    }
}
