using System;
using System.Text;

namespace Sicurezza
{
    public static class SettingsSicurezza
    {
        private static byte[] IV = Encoding.ASCII.GetBytes("@@Aziend@@");
        private static byte[] Key = Encoding.ASCII.GetBytes("___::::___DDoS___::::___");
        private static Algorithm Algoritmo = Algorithm.Rijndael;

        static SettingsSicurezza()
        {
        }

        public static string Decrypt(string crypted)
        {
            string str = string.Empty;
            try
            {
                byte[] bytesData = Convert.FromBase64String(crypted);
                byte[] output = (byte[])null;
                Decryptor.Decrypt(SettingsSicurezza.Algoritmo, bytesData, SettingsSicurezza.Key, SettingsSicurezza.IV, out output);
                if (output == null)
                    throw new Exception("Errore: Impossibile decriptare i dati.");
                else
                    return Encoding.ASCII.GetString(output);
            }
            catch (Exception ex)
            {
                throw new Exception("Errore: " + ex.Message);
            }
        }

        public static string Encrypt(string decrypted)
        {
            string str = string.Empty;
            try
            {
                byte[] output = (byte[])null;
                byte[] bytes = Encoding.ASCII.GetBytes(decrypted);
                Encryptor.Encrypt(SettingsSicurezza.Algoritmo, bytes, SettingsSicurezza.Key, SettingsSicurezza.IV, out output);
                if (output == null)
                    throw new Exception("Errore: Impossibile criptare i dati.");
                else
                    return Convert.ToBase64String(output);
            }
            catch (Exception ex)
            {
                throw new Exception("Errore: " + ex.Message);
            }
        }
    }
}
