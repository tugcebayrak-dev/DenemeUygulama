using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Araclar
{
    public class Sifreleme
    {
        public static string Encrypt(string toEncrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            string key = Sabitler.DEFAULT_KEY;
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string cipherString)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);
            string key = Sabitler.DEFAULT_KEY;
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static string IdSifrele(int Id)
        {
            var str = Id.ToString();
            return str.Replace("1", "xvCretb").Replace("2", "ftFrrsd").Replace("3", "cjoYtV").Replace("4", "JkTEOu").Replace("5", "YihEr").Replace("6", "wevsRTlkp").Replace("7", "zSEslpiru").Replace("8", "oNsadjplkj").Replace("9", "Nimbg").Replace("0", "FjrtT");
        }

        public static int IdCoz(string str)
        {
            int a = 0;
            try
            {
                var ssss = str.Replace("xvCretb", "1").Replace("ftFrrsd", "2").Replace("cjoYtV", "3").Replace("JkTEOu", "4").Replace("YihEr", "5").Replace("wevsRTlkp", "6").Replace("zSEslpiru", "7").Replace("oNsadjplkj", "8").Replace("Nimbg", "9").Replace("FjrtT", "0");
                int.TryParse(ssss, out a);
                return a;
            }
            catch (Exception ex)
            {
                var sonuc = ex.Message;
                return a;
            }
        }

        public static string SifreCoz(String hexInput, Encoding encoding)
        {
            if (hexInput == null)
            {
                return "";
            }

            int numberChars = hexInput.Length;
            var bytes = new byte[numberChars / 2];
            try
            {

                for (int i = 0; i < numberChars; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
                }
                return encoding.GetString(bytes);
            }
            catch (Exception)
            {
                //	Log.Instance.Yaz(ex.Message);
                return "Geçersiz kod";
            }
        }

    }
}
