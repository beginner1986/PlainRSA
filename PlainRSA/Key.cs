using Org.BouncyCastle.Math;

namespace PlainRSA
{
    class Key
    {
        private readonly BigInteger value;
        private readonly BigInteger modulus;

        public Key(BigInteger value, BigInteger modulus)
        {
            this.value = value;
            this.modulus = modulus;
        }

        public BigInteger GetValue() { return value; }

        public BigInteger GetModulus() { return modulus; }
    }
}
