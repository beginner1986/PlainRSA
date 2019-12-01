using System;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

// this class is responsible for keys generation, encryption, decryption 
// and storing the private key.
namespace PlainRSA
{
    class RSA
    {
        private readonly int security;      // security level, given as parameter
        private readonly Key publicKey;
        private readonly Key privateKey;
        private BigInteger p;               // the first big prime number
        private BigInteger q;               // the second big prime number
        private readonly BigInteger m;      // m = p * q, modulus, common for all the keys
        private readonly BigInteger fi;     // fi = (p - 1) 8 (q - 1)

        private const int publicKeyLength = 16;     // as fixed value

        public RSA(int security)
        {
            this.security = security;
            
            // generate base primes p and q
            Task generateP = new Task(() =>
                { p = BigInteger.ProbablePrime(security / 2, new SecureRandom()); });

            Task generateQ = new Task(() =>
                { q = BigInteger.ProbablePrime(security / 2, new SecureRandom()); });
            
            // do it parallel
            generateP.Start();
            generateQ.Start();
            // continue only when both tasks are done
            Task.WaitAll(generateP, generateQ);

            // the modulus
            m = p.Multiply(q);

            // fi(m) - coprimes numbr
            fi = p.Subtract(BigInteger.One).Multiply(q.Subtract(BigInteger.One));

            // generate the keys - public key must be first
            publicKey = GeneratePublicKey();
            privateKey = GeneratePrivateKey();
        }

        public byte[] Encrypt(string plainText, Key publicKey)
        {
            // convert plain text to bytes array
            byte[] bytes = Encoding.UTF8.GetBytes(plainText);
            // use it as parameter of BigInteger constructor
            BigInteger result = new BigInteger(bytes);
            
            // M^e (mod m) - calculated on all the plain text and converted to bytes array
            return result.ModPow(publicKey.GetValue(), publicKey.GetModulus()).ToByteArray();
        }

        public string Decrypt(byte[] encrypted)
        {
            // create new BigInteger containing encrypted text bytes
            BigInteger result = new BigInteger(encrypted);
            // M^d (mod m) - calculated on all the encrypted text  
            result = result.ModPow(privateKey.GetValue(), privateKey.GetModulus());

            // convert BigInteger result to bytes array and return it converted to string
            return Encoding.UTF8.GetString(result.ToByteArray());
        }

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
            // e * d (mod fi)
            BigInteger test = publicKey.GetValue().Multiply(privateKey.GetValue()).Mod(fi);
            // print the result
            if (test.CompareTo(BigInteger.One) == 0)
                Console.Write("OK");
            else
                Console.Write("FAILED");
        }

        private Key GeneratePrivateKey()
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
            // two numbers are coprime if their GCD is 1

            //get random BigInteger
            BigInteger result = new BigInteger(bitlength, new SecureRandom());

            // if it is coprime with given number break
            while(number.Gcd(result).CompareTo(BigInteger.One) != 0)
            {
                // if it is not coprime then increment
                result = result.Add(BigInteger.One);
            }

            return result;
        }

        // publish your public key
        public Key GetPublicKey() { return publicKey; }
    }
}
