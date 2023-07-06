using System;
using System.IO;
using System.Security.Cryptography;

namespace Sicurezza
{
    public static class Decryptor
    {
        public static void Decrypt(Algorithm algId, byte[] bytesData, byte[] bytesKey, byte[] bytesIV, out byte[] output)
        {
            DecryptTransformer decryptTransformer = (DecryptTransformer)null;
            CryptoStream cryptoStream = (CryptoStream)null;
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                decryptTransformer = new DecryptTransformer(algId, bytesKey, bytesIV);
                ICryptoTransform cryptoServiceProvider = decryptTransformer.GetCryptoServiceProvider();
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
                if (decryptTransformer != null)
                    decryptTransformer.Dispose();
            }
        }
    }
}