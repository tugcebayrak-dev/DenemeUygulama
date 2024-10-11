using System;
using System.Globalization;

namespace DenemeUygulama.Data.Netsis
{
    public class NetsisHelper
    {
        public string ConvertDateTimeByString(string date)
        {
            if (string.IsNullOrWhiteSpace(date))
                return string.Empty;

            DateTime dateTime = Convert.ToDateTime(date);

            return dateTime.ToString("yyyy-MM-dd");
        }

        public string ToNetsis(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return string.Empty;

            word = word.Replace("Ğ", "Ð");
            word = word.Replace("Ü", "Ü");
            word = word.Replace("Ş", "Þ");
            word = word.Replace("İ", "Ý");
            word = word.Replace("Ö", "Ö");
            word = word.Replace("Ç", "Ç");
            word = word.Replace("I", "I");
            word = word.Replace("ğ", "ð");
            word = word.Replace("ü", "ü");
            word = word.Replace("ş", "þ");
            word = word.Replace("i", "i");
            word = word.Replace("ö", "ö");
            word = word.Replace("ç", "ç");
            word = word.Replace("ı", "ý");

            return word;
        }
        public string FromNetsis(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return string.Empty;

            word = word.Replace("Ð", "Ğ");
            word = word.Replace("Ü", "Ü");
            word = word.Replace("Þ", "Ş");
            word = word.Replace("Ý", "İ");
            word = word.Replace("Ö", "Ö");
            word = word.Replace("Ç", "Ç");
            word = word.Replace("I", "I");
            word = word.Replace("ð", "ğ");
            word = word.Replace("ü", "ü");
            word = word.Replace("þ", "ş");
            word = word.Replace("i", "i");
            word = word.Replace("ö", "ö");
            word = word.Replace("ç", "ç");
            word = word.Replace("ý", "ı");

            return word;
        }
        public static string ToUrl(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return string.Empty;

            word = word.Replace("ş", "s"); word = word.Replace("Ş", "S"); word = word.Replace(".", "");
            word = word.Replace(":", ""); word = word.Replace(";", ""); word = word.Replace(",", "");
            word = word.Replace(" ", "-"); word = word.Replace("!", ""); word = word.Replace("(", "");
            word = word.Replace(")", ""); word = word.Replace("'", ""); word = word.Replace("ğ", "g");
            word = word.Replace("Ğ", "G"); word = word.Replace("ı", "i"); word = word.Replace("I", "i");
            word = word.Replace("ç", "c"); word = word.Replace("ç", "C"); word = word.Replace("ö", "o");
            word = word.Replace("Ö", "O"); word = word.Replace("ü", "u"); word = word.Replace("Ü", "U");
            word = word.Replace("`", ""); word = word.Replace("=", ""); word = word.Replace("&", "");
            word = word.Replace("%", ""); word = word.Replace("#", ""); word = word.Replace("<", "");
            word = word.Replace(">", ""); word = word.Replace("*", ""); word = word.Replace("?", "");
            word = word.Replace("+", "-"); word = word.Replace("\"", "-"); word = word.Replace("»", "-");
            word = word.Replace("|", "-"); word = word.Replace("^", "");

            return word;
        }

        public string TurkceKarakterKullanma(string word)
        {
            word = word.Replace("ş", "s"); word = word.Replace("Ş", "S");
            word = word.Replace("ğ", "g"); word = word.Replace("Ğ", "G");
            word = word.Replace("ı", "i"); word = word.Replace("I", "i");
            word = word.Replace("ç", "c"); word = word.Replace("ç", "C");
            word = word.Replace("ö", "o"); word = word.Replace("Ö", "O");
            word = word.Replace("ü", "u"); word = word.Replace("Ü", "U");
            //word = word.Replace(" ", "_");

            return word;
        }
        public string NetsisSiradakiNumara(string number, string serial)
        {
            number = (Convert.ToDouble(number.Substring(serial.Length, number.Length - serial.Length)) + 1).ToString(CultureInfo.InvariantCulture);

            return serial + number.PadLeft(15 - serial.Length, '0');
        }
    }
}
