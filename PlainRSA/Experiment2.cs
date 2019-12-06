using System;
using System.Text;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

namespace PlainRSA
{
    class Experiment2
    {
        static readonly int messageSize = 16;

        static void Main(string[] args)
        {
            // encryptor / decryptor object
            RSA rsa = new RSA(2048);
            Key key = rsa.GetPublicKey();

            // Messages m, m1, m2, where m = m1 * m2
            BigInteger m1 = new BigInteger(messageSize / 2, new SecureRandom());
            BigInteger m2 = new BigInteger(messageSize / 2, new SecureRandom());
            BigInteger m = m1.Multiply(m2).Mod(key.GetModulus());

            // get the intermediate signatures s1 and s2
            byte[] s1 = rsa.Encrypt(m1.ToString(), key);
            byte[] s2 = rsa.Encrypt(m2.ToString(), key);
            byte[] s;

            // calculate signature s = s1 * s2
            BigInteger bigS1 = new BigInteger(s1);
            BigInteger bigS2 = new BigInteger(s2);
            BigInteger bigS = bigS1.Multiply(bigS2).Mod(key.GetModulus());
            s = bigS.ToByteArray();

            // get the correct signature to compare
            byte[] originalS = rsa.Encrypt(m.ToString(), key);

            // print the resultss
            Console.WriteLine("Oryginalny podpis:");
            Console.WriteLine(BitConverter.ToString(originalS).Replace("-", "") + "\n");
            Console.WriteLine("Podpis wyliczony z zależności s = s1 * s2 (mod n):");
            Console.WriteLine(BitConverter.ToString(s).Replace("-", "") + "\n");

            // restore the message from calculated signature
            string restored = rsa.Decrypt(bigS.ToByteArray());
            byte[] restoredBytes = Encoding.UTF8.GetBytes(restored);
            BigInteger bigRestored = new BigInteger(restoredBytes);

            Console.WriteLine("Oryginalna wiadomość:");
            Console.WriteLine(m.ToString());
            Console.WriteLine("Wiadomość odtworzona z podpisu s:");
            Console.WriteLine(bigRestored.ToString());
        }
    }
}
