using System;
using Org.BouncyCastle.Math;

namespace PlainRSA
{
    class RSA
    {
        private readonly int security;
        private readonly Key publicKey;
        private readonly Key privateKey;
        private readonly BigInteger modulus;

        public RSA(int security)
        {
            this.security = security;

            publicKey = GeneratePublicKey();
            privateKey = GeneratePrivateKey();

            // TODO: generate modulus
        }

        public byte[] Encrypt(string plainText, Key publicKey)
        {
            // TODO
        }

        public string Decrypt(byte[] encrypted)
        {
            // TODO
        }

        private Key GeneratePrivateKey()
        {
            // TODO
        }

        private Key GeneratePublicKey()
        {
            // TODO
        }

        public Key GetPublicKey() { return publicKey; }
    }
}
