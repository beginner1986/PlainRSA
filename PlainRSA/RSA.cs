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

            // the modulus
            m = p.Multiply(q);
            
            // fi(m) - coprimes numbr
            fi = p.Subtract(BigInteger.One).Multiply(q.Subtract(BigInteger.One));

            // generate the keys
            publicKey = GeneratePublicKey();
            privateKey = GeneratePrivateKey(security);
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

        //don't charge me, it's only for this task purposes ;)
        //private key is unavailable outside the RSA class, so this method
        //is necessary to prove that everything works correctly
        public void ShowMySecrets()
        {
            Console.WriteLine("Bezpieczeństwo: {0} bitów", security);
            Console.WriteLine("Klucz publiczny:");
            Console.WriteLine(publicKey.GetValue().ToString());
            Console.WriteLine("Klucz prywatny:");
            Console.WriteLine(privateKey.GetValue().ToString());

            // perform ed test
            Console.Write("Test e*d == 1: ");
            BigInteger test = publicKey.GetValue().Multiply(privateKey.GetValue()).Mod(fi);
            if (test.CompareTo(BigInteger.One) == 0)
                Console.Write("OK");
            else
                Console.Write("FAILED");
        }

        private Key GeneratePrivateKey(int security)
        {
            BigInteger e = publicKey.GetValue();
            BigInteger d = e.ModInverse(fi);

            Key result = new Key(d, m);

            return result;
        }

        private Key GeneratePublicKey()
        {
            BigInteger e = GetCoprime(publicKeyLength, fi);

            Key result = new Key(e, m);

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
