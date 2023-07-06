using System;
using System.IO;
using System.Security.Cryptography;

namespace Sicurezza
{
    public static class Encryptor
    {
        public static void Encrypt(Algorithm algId, byte[] bytesData, byte[] bytesKey, byte[] bytesIV, out byte[] output)
        {
            EncryptTransformer encryptTransformer = (EncryptTransformer)null;
            CryptoStream cryptoStream = (CryptoStream)null;
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                encryptTransformer = new EncryptTransformer(algId, bytesKey, bytesIV);
                ICryptoTransform cryptoServiceProvider = encryptTransformer.GetCryptoServiceProvider();
                cryptoStream = new CryptoStream((Stream)memoryStream, cryptoServiceProvider, CryptoStreamMode.Write);
                cryptoStream.Write(bytesData, 0, bytesData.Length);
                cryptoStream.FlushFinalBlock();
                output = memoryStream.ToArray();
            }
            catch (Exception ex)
            {
                output = (byte[])null;
            }
            finally
            {
                if (cryptoStream != null)
                    cryptoStream.Close();
                if (encryptTransformer != null)
                    encryptTransformer.Dispose();
            }
        }
    }
}