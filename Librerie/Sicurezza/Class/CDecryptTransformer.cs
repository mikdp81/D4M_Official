using System;
using System.Security.Cryptography;

namespace Sicurezza
{
    internal class DecryptTransformer : ITransformer, IDisposable
    {
        private Algorithm algorithmID;
        private byte[] initVec;
        private byte[] initKey;

        public byte[] IV
        {
            set
            {
                this.initVec = value;
            }
        }

        public byte[] Key
        {
            set
            {
                this.initKey = value;
            }
        }

        internal DecryptTransformer(Algorithm deCryptId)
        {
            this.algorithmID = deCryptId;
        }

        internal DecryptTransformer(Algorithm deCryptId, byte[] bytesKey, byte[] bytesIV)
        {
            this.algorithmID = deCryptId;
            this.initVec = bytesIV;
            this.initKey = bytesKey;
        }

        ~DecryptTransformer()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            this.initVec = (byte[])null;
            this.initKey = (byte[])null;
        }

        public ICryptoTransform GetCryptoServiceProvider()
        {
            switch (this.algorithmID)
            {
                case Algorithm.Des:
                    DES des = (DES)new DESCryptoServiceProvider();
                    des.Mode = CipherMode.CBC;
                    des.Key = this.initKey;
                    des.IV = this.initVec;
                    return des.CreateDecryptor();
                case Algorithm.Rc2:
                    RC2 rc2 = (RC2)new RC2CryptoServiceProvider();
                    rc2.Mode = CipherMode.CBC;
                    return rc2.CreateDecryptor(this.initKey, this.initVec);
                case Algorithm.Rijndael:
                    Rijndael rijndael = (Rijndael)new RijndaelManaged();
                    rijndael.Mode = CipherMode.CBC;
                    return rijndael.CreateDecryptor(this.initKey, this.initVec);
                case Algorithm.TripleDes:
                    TripleDES tripleDes = (TripleDES)new TripleDESCryptoServiceProvider();
                    tripleDes.Mode = CipherMode.CBC;
                    return tripleDes.CreateDecryptor(this.initKey, this.initVec);
                default:
                    throw new CryptographicException("Algoritmo '" + (object)this.algorithmID + "' non supportato.");
            }
        }
    }
}