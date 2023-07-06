using System;
using System.Security.Cryptography;

namespace Sicurezza
{
    internal class EncryptTransformer : ITransformer, IDisposable
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

        internal EncryptTransformer(Algorithm enCryptId)
        {
            this.algorithmID = enCryptId;
        }

        internal EncryptTransformer(Algorithm enCryptId, byte[] bytesKey, byte[] bytesIV)
        {
            this.algorithmID = enCryptId;
            this.initVec = bytesIV;
            this.initKey = bytesKey;
        }

        ~EncryptTransformer()
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
                    if (this.initKey == null)
                        this.initKey = des.Key;
                    else
                        des.Key = this.initKey;
                    if (this.initVec == null)
                        this.initVec = des.IV;
                    else
                        des.IV = this.initVec;
                    return des.CreateEncryptor();
                case Algorithm.Rc2:
                    RC2 rc2 = (RC2)new RC2CryptoServiceProvider();
                    rc2.Mode = CipherMode.CBC;
                    if (this.initKey == null)
                        this.initKey = rc2.Key;
                    else
                        rc2.Key = this.initKey;
                    if (this.initVec == null)
                        this.initVec = rc2.IV;
                    else
                        rc2.IV = this.initVec;
                    return rc2.CreateEncryptor();
                case Algorithm.Rijndael:
                    Rijndael rijndael = (Rijndael)new RijndaelManaged();
                    rijndael.Mode = CipherMode.CBC;
                    if (this.initKey == null)
                        this.initKey = rijndael.Key;
                    else
                        rijndael.Key = this.initKey;
                    if (this.initVec == null)
                        this.initVec = rijndael.IV;
                    else
                        rijndael.IV = this.initVec;
                    return rijndael.CreateEncryptor();
                case Algorithm.TripleDes:
                    TripleDES tripleDes = (TripleDES)new TripleDESCryptoServiceProvider();
                    tripleDes.Mode = CipherMode.CBC;
                    if (this.initKey == null)
                        this.initKey = tripleDes.Key;
                    else
                        tripleDes.Key = this.initKey;
                    if (this.initVec == null)
                        this.initVec = tripleDes.IV;
                    else
                        tripleDes.IV = this.initVec;
                    return tripleDes.CreateEncryptor();
                default:
                    throw new CryptographicException("Algoritmo '" + (object)this.algorithmID + "' non supportato.");
            }
        }
    }
}
