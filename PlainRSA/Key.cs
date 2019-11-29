using Org.BouncyCastle.Math;

namespace PlainRSA
{
    class Key
    {
        // key value, e for public and d for private key
        private readonly BigInteger value;
        // key modulus n or m, depends on source
        private readonly BigInteger modulus;

        // only one constructor and getters, because the key is immutable
        public Key(BigInteger value, BigInteger modulus)
        {
            this.value = value;
            this.modulus = modulus;
        }

        public BigInteger GetValue() { return value; }

        public BigInteger GetModulus() { return modulus; }
    }
}
