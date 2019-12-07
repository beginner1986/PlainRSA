using System;
using System.Collections.Generic;
using System.Text;
using Org.BouncyCastle.Math;

namespace PlainRSA
{
    public class Experiment3
    {
        RSA rsa;
        Key key;
        public Experiment3()
        {
            // encryptor / decryptor object
            rsa = new RSA(2048);
            key = rsa.GetPublicKey();
        }

        public void Start()
        {

            BigInteger s = new BigInteger("2829246759667430901779973875");
            BigInteger N = new BigInteger("74863748466636279180898113945573168800167314349007339734664557033677222985045895878321130196223760783214379338040678233908010747773264003237620590141174028330154012139597068236121542945442426074367017838349905866915120469978361986002240362282392181726265023378796284600697013635003150020012763665368297013349");
            int e = 3;

            // TODO
            BigInteger m = BruteTest(new BigInteger("1400000000"), s);

            Console.WriteLine("Eksperyment 3:\n");
            Console.WriteLine($"Rzeczywiste s: {s}");
            Console.WriteLine($"Obliczone s (m^e): {m.Pow(e)}");
            Console.WriteLine($"Obliczone m: {m.ToString()}");
            Console.WriteLine($"Odtworzony tekst jawny: {Encoding.UTF8.GetString(m.ToByteArray())}");
        }

        private BigInteger BruteTest(BigInteger input, BigInteger target)
        {
            BigInteger result = input;

            while(result.Pow(3).CompareTo(target) < 0)
            {
                result = result.Add(BigInteger.One);
            }

            return result;
        }
    }
}
