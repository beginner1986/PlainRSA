using System;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

namespace PlainRSA
{
    class RSA
    {
        private readonly int security;
        private readonly Key publicKey;
        private readonly Key privateKey;
        private readonly BigInteger p;
        private readonly BigInteger q;
        private readonly BigInteger m;
        private readonly BigInteger fi;

        private const int publicKeyLength = 16;

        public RSA(int security)
        {
            this.security = security;

            // generate base primes
            p = BigInteger.ProbablePrime(security, new SecureRandom());
            q = BigInteger.ProbablePrime(security, new SecureRandom());

            // DEBUG
            Console.WriteLine("Random numbers generated");

            // the modulus
            m = p.Multiply(q);
            
            // DEBUG
            Console.WriteLine("Modulus generated");

            // fi(m) - coprimes numbr
            fi = p.Subtract(BigInteger.One).Multiply(q.Subtract(BigInteger.One));

            // DEBUG
            Console.WriteLine("Fi value generated");

            // generate the keys
            publicKey = GeneratePublicKey();
            privateKey = GeneratePrivateKey();

            // perform ed test
            Console.Write("Test e*d == 1: ");
            BigInteger test = publicKey.GetValue().Multiply(privateKey.GetValue()).Mod(fi);
            if (test.CompareTo(BigInteger.One) == 0)
                Console.Write("OK");
            else
                Console.Write("FAILED");
        }

        /*
        public byte[] Encrypt(string plainText, Key publicKey)
        {
            // TODO
            byte[] bytes = Encoding.UTF8.GetBytes(plainText);
        }

        public string Decrypt(byte[] encrypted)
        {
            // TODO
        }
        */

        private Key GeneratePrivateKey()
        {
            BigInteger d = new BigInteger(m.BitLength, new SecureRandom());

            // temp = e * d (mod m)
            BigInteger temp = d.Multiply(publicKey.GetValue()).Mod(fi);

            // if(temp != 1)
            if(temp.CompareTo(BigInteger.One) != 0)
            {
                d = d.Add(temp.Subtract(BigInteger.One));
            }

            Key result = new Key(d, m);

            // DEBUG
            Console.Write("Private key generated: ");
            Console.WriteLine(d.ToString());

            return result;
        }

        private Key GeneratePublicKey()
        {
            BigInteger e = GetCoprime(publicKeyLength, fi);

            Key result = new Key(e, m);

            // DEBUG
            Console.Write("Public key generated: ");
            Console.WriteLine(e.ToString());

            return result;
        }
        
        private BigInteger GetCoprime(int bitlength, BigInteger number)
        {
            BigInteger result;

            do
            {
                result = new BigInteger(bitlength, new SecureRandom());
            } while (number.Gcd(result).CompareTo(BigInteger.One) != 0);

            return result;
        }

        public Key GetPublicKey() { return publicKey; }
    }
}
