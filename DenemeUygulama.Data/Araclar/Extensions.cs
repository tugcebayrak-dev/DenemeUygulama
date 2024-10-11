using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using DenemeUygulama.Data.Entity.Models;
using DenemeUygulama.Data.Entity.UnitOfWork;
using DenemeUygulama.Data.Entity.Context;
using static DenemeUygulama.Data.Araclar.Enums;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Net.Mail;

namespace DenemeUygulama.Data.Araclar
{
    public static class Extensions
    {
        public static bool IsNull(this object value)
        {
            try
            {
                return value == null;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public static bool IsNotNull(this object value)
        {
            try
            {
                return value != null;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public static int ToInt32(this string value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }

        public static bool ToBool(this string value)
        {
            try
            {
                return Convert.ToBoolean(value);
            }
            catch
            {
                return false;
            }

        }
        public static int ToInt32(this decimal value)
        {
            return Convert.ToInt32(value);
        }
        public static int ToInt32(this double? value)
        {
            return Convert.ToInt32(value);
        }
        public static int ToInt32(this object value)
        {
            return Convert.ToInt32(value);
        }
        public static double ToDouble(this string value)
        {
            double deger = 0;
            if (!double.TryParse(value, out deger))
            {
                deger = 0;
            }
            return deger;
        }
        public static double ToDouble(this int value)
        {
            return Convert.ToDouble(value);
        }
        public static decimal ToDecimal(this string value)
        {
            decimal obj = 0;
            try
            {
                decimal.TryParse(value, out obj);
                return obj;
            }
            catch (Exception)
            {
                return obj;
            }
        }

        public static DateTime ToDateTime(this object value)
        {
            return Convert.ToDateTime(value);
        }
        public static decimal CustomParse(string incomingValue)
        {
            decimal val = 0;
            if (!decimal.TryParse(incomingValue.Replace(",", "").Replace(".", ""), NumberStyles.Number, CultureInfo.InvariantCulture, out val))
                return val;

            return val / 100;
        }
        public static int IsNullReturnZero(this int? value)
        {
            if (value == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(value);
            }
        }
        public static byte ToByte(this string value)
        {
            return Convert.ToByte(value);
        }
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
        public static string GetValue(this string value)
        {
            return !value.IsNullOrEmpty() ? value : string.Empty;
        }
        public static string SetValue(this string value)
        {
            return (!string.IsNullOrEmpty(value) ? value.Trim() : string.Empty);
        }
        public static string SetValue(this object value)
        {
            return (value != null ? value.ToString() : string.Empty);
        }
        public static string ToUpperCase(this string value)
        {
            return string.IsNullOrEmpty(value) ? value : (value.Trim()).ToUpper();
        }
        public static string ToUpperCaseNoTrk(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? value : (value.Trim()).ToUpper()
                .Replace("Ç", "C")
                .Replace("Ğ", "G")
                .Replace("İ", "I")
                .Replace("Ö", "O")
                .Replace("Ş", "S")
                .Replace("Ü", "U")
                .Replace("'", "")
                .Replace("%", "")
                .Replace("\"", "")
                .Replace("!", "")
                .Replace("?", "?")
                .Replace("/", "");
        }
        public static string ToFirstCharacterUpper(this string value)
        {
            value = value.Trim();
            if (string.IsNullOrEmpty(value))
                return value;
            else
            {
                string strValue = "";
                foreach (var item in value.Split(' '))
                {
                    strValue += item.Length > 1 ? item.First().ToString().ToUpper() + item.Substring(1).ToLower() + " " : item.ToUpper() + " ";
                }
                return strValue.Trim();
            }
        }
        public static DateTime HaftaninIlkGunu(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }
        public static DateTime AyinIlkGunu(this DateTime date)
        {
            if (date == null)
                throw new ArgumentNullException(nameof(date));

            return new DateTime(date.Year, date.Month, 1);
        }
        public static DateTime AyinSonGunu(this DateTime date)
        {
            if (date == null)
                throw new ArgumentNullException(nameof(date));

            return date.AyinIlkGunu().AddMonths(1).AddDays(-1);
        }
        public static string MetodAdi(this Exception exception)
        {
            var trace = new StackTrace(exception);
            var frames = trace.GetFrames().Reverse();
            var metodlar = "\nHatanın oluştuğu yer :\n";
            foreach (var frame in frames)
            {
                var method = frame.GetMethod();
                if (method.DeclaringType != null)
                    metodlar += string.Concat(method.DeclaringType.FullName, " -> ", method.Name + "\n");
            }
            metodlar += "----------------------";
            return metodlar;
        }
        public static string NextCode(this string Code)
        {
            byte[] ASCIIValues = Encoding.UTF8.GetBytes(Code.ToUpper());
            int StringLength = ASCIIValues.Length;
            bool isAllZed = true;
            bool isAllNine = true;


            for (int i = 0; i < StringLength - 1; i++)
            {
                if (ASCIIValues[i] != 90)
                {
                    isAllZed = false;
                    break;
                }
            }
            if (isAllZed && ASCIIValues[StringLength - 1] == 57)
            {
                ASCIIValues[StringLength - 1] = 64;
            }


            for (int i = 0; i < StringLength; i++)
            {
                if (ASCIIValues[i] != 57)
                {
                    isAllNine = false;
                    break;
                }
            }
            if (isAllNine)
            {
                ASCIIValues[StringLength - 1] = 47;
                ASCIIValues[0] = 65;
                for (int i = 1; i < StringLength - 1; i++)
                {
                    ASCIIValues[i] = 48;
                }
            }


            for (int i = StringLength; i > 0; i--)
            {
                if (i - StringLength == 0)
                {
                    ASCIIValues[i - 1] += 1;
                }
                if (ASCIIValues[i - 1] == 58)
                {
                    ASCIIValues[i - 1] = 48;
                    if (i - 2 == -1)
                    {
                        break;
                    }
                    ASCIIValues[i - 2] += 1;
                }
                else if (ASCIIValues[i - 1] == 91)
                {
                    ASCIIValues[i - 1] = 65;
                    if (i - 2 == -1)
                    {
                        break;
                    }
                    ASCIIValues[i - 2] += 1;

                }
                else
                {
                    break;
                }

            }
            Code = System.Text.Encoding.UTF8.GetString(ASCIIValues);
            return Code;
        }
        public static string BytesToSize(this object value)
        {
            try
            {
                var newvalue = Convert.ToInt64(value);
                string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
                if (newvalue < 0) { return "-"; }
                if (newvalue == 0) { return "0 bytes"; }

                int mag = (int)Math.Log(newvalue, 1024);
                decimal adjustedSize = (decimal)newvalue / (1L << (mag * 10));

                if (Math.Round(adjustedSize, 1) >= 1000)
                {
                    mag += 1;
                    adjustedSize /= 1024;
                }

                return string.Format("{0:n" + 1 + "} {1}",
                    adjustedSize,
                    SizeSuffixes[mag]);
            }
            catch (Exception)
            {
                return "-";
            }
        }
        public static string IlkNKarakter(this string str, int maxLength, string lastCharacter)
        {
            if (str.Length <= maxLength)
                return str;
            else
            {
                if (lastCharacter == "")
                    return str.Substring(0, Math.Min(str.Length, maxLength));
                else
                    return str.Substring(0, Math.Min(str.Length, maxLength)) + lastCharacter;
            }

        }
        public static DateTime ToDateTime(this string value)
        {
            DateTime deger = DateTime.MinValue;
            if (!DateTime.TryParse(value, out deger))
            {
                deger = DateTime.MinValue;
            }
            return deger;
        }
        public static string JavaScriptEscape(this string value)
        {
            return (!string.IsNullOrEmpty(value) ? value.Replace("\\", @"\u005c").Replace("\"", @"\u0022").Replace("'", @"\u0027").Replace("&", @"\u0026").Replace("<", @"\u003c").Replace(">", @"\u003e") : string.Empty);
        }
        public static string NetsisDboTrk(this string value)
        {

            //I Ğ Ü Ş İ Ö Ç   ı ğ ü ş i ö ç 
            //I Ð Ü Þ Ý Ö Ç   ý ð ü þ i ö ç 

            value = value.Replace('I', 'I')
                         .Replace('Ð', 'Ğ')
                         .Replace("Ü", "Ü")
                         .Replace("Þ", "Ş")
                         .Replace("Ý", "İ")
                         .Replace("Ö", "Ö")
                         .Replace("Ç", "Ç")
                         .Replace("ý", "ı")
                         .Replace("ð", "ğ")
                         .Replace("ü", "ü")
                         .Replace("þ", "ş")
                         .Replace("i", "i")
                         .Replace("ö", "ö")
                         .Replace("ç", "ç");
            return value;
        }

        public static string TrkToNetsis(this string value)
        {

            //I Ğ Ü Ş İ Ö Ç   ı ğ ü ş i ö ç 
            //I Ð Ü Þ Ý Ö Ç   ý ð ü þ i ö ç 

            value = value.Replace('I', 'I')
                         .Replace('Ğ', 'Ð')
                         .Replace("Ü", "Ü")
                         .Replace("Ş", "Þ")
                         .Replace("İ", "Ý")
                         .Replace("Ö", "Ö")
                         .Replace("Ç", "Ç")
                         .Replace("ı", "ý")
                         .Replace("ğ", "ð")
                         .Replace("ü", "ü")
                         .Replace("ş", "þ")
                         .Replace("i", "i")
                         .Replace("ö", "ö")
                         .Replace("ç", "ç");
            return value;
        }
        public static string SQLLikeTrk(this string value)
        {
            value = value.Replace('İ', '_');
            return value;
        }


        public static bool EmailIsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        #region Enum Extensions

        public static string GetEnumAciklama(this Enum value)
        {
            try
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());

                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

                if (attributes != null &&
                    attributes.Length > 0)
                    return attributes[0].Description;
                else
                    return value.ToString();
            }
            catch (Exception ex)
            {
                Log.Instance.Yaz(ex.ToString());
                return string.Empty;
            }
        }

        public static string GetEnumValue(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DefaultValueAttribute[] attributes =
                (DefaultValueAttribute[])fi.GetCustomAttributes(
                typeof(DefaultValueAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Value.ToString();
            else
                return value.ToString();
        }

        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", nameof(description));
            // or return default(T);
        }

        public static List<KeyValuePair<string, int>> GetEnumValuesAndDescriptions<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T is not System.Enum");



            List<KeyValuePair<string, int>> enumValList = new List<KeyValuePair<string, int>>();
            foreach (var e in Enum.GetValues(typeof(T)))
            {

                var fi = e.GetType().GetField(e.ToString());
                DefaultValueAttribute[] defAttributes = (DefaultValueAttribute[])fi.GetCustomAttributes(typeof(DefaultValueAttribute), false);
                var defEnumString = string.Empty;
                if (defAttributes != null && defAttributes.Length > 0)
                    defEnumString = defAttributes[0].Value.ToString();
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                enumValList.Add(new KeyValuePair<string, int>((attributes.Length > 0) ? attributes[0].Description : e.ToString(), (int)e));
            }

            return enumValList;
        }

        public static List<Tuple<string, int, bool>> GetEnumValuesAndDefaultDescriptions<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T is not System.Enum");

            DefaultValueAttribute[] defAttributes = (DefaultValueAttribute[])enumType.GetCustomAttributes(typeof(DefaultValueAttribute), false);
            var defEnumString = string.Empty;

            if (defAttributes != null && defAttributes.Length > 0)
                defEnumString = defAttributes[0].Value.ToString();


            List<Tuple<string, int, bool>> enumValList = new List<Tuple<string, int, bool>>();
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                var fi = e.GetType().GetField(e.ToString());

                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    enumValList.Add(new Tuple<string, int, bool>(attributes[0].Description, (int)e, e?.ToString() == defEnumString));
                }
                else
                    enumValList.Add(new Tuple<string, int, bool>(e.ToString(), (int)e, e?.ToString() == defEnumString));
            }

            return enumValList;
        }




        //tSiparisKalem classini viewSiparisKalem clasina hızlı cast etmek için yazıldı property name aynı olanları eşitleyip geri döner
        public static T BenzerClassaCast<T>(this Object myobj)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                value = myobj.GetType().GetProperty(memberInfo.Name)?.GetValue(myobj, null);

                propertyInfo.SetValue(x, value, null);
            }
            return (T)x;
        }
       

        /// <summary>
        /// Gridi multi select olarak kullanıyorsanız bu method ile seçilen satırların listesini alabilirsiniz. Projenizde gridview referance si ekli olması gerekmektedir.(Bu yüzden yorum yaptım)
        /// </summary>
        /// <typeparam name="T">Gridi load ederken kullandığınız class</typeparam>
        /// <param name="grid">Gridview</param>
        /// <returns></returns>
        //public static List<T> GetSelectedRowsList<T>(this GridView grid) where T : class
        //{
        //    var list = new List<T>();
        //    try
        //    {
        //        foreach (var item in grid.GetSelectedRows())
        //        {
        //            var rowData = grid.GetRow(item) as T;
        //            if (rowData != null)
        //                list.Add(rowData);
        //        }
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Instance.Yaz(ex);
        //        return list;
        //    }
        //}

        //devexpress gridlerde selectedItema olan objenin field adı verilerek değerini almak için yazılıdı
        public static object GetObjectPropertyValue(this object value, string propertyName)
        {
            System.Reflection.PropertyInfo pi = value.GetType().GetProperty(propertyName);
            return pi.GetValue(value, null);
        }
        
        public static List<T> CastList<T>(this DataTable dataTable)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dataRow)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dataRow.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName && dataRow[column.ColumnName] != DBNull.Value)
                        pro.SetValue(obj, dataRow[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        //public static string MetodAdi(this Exception exception)
        //{
        //    var trace = new StackTrace(exception);
        //    var frames = trace.GetFrames().Reverse();
        //    var metodlar = "\nHatanın oluştuğu yer :\n";
        //    foreach (var frame in frames)
        //    {
        //        var method = frame.GetMethod();
        //        if (method.DeclaringType != null)
        //            metodlar += string.Concat(method.DeclaringType.FullName, " -> ", method.Name + "\n");
        //    }
        //    metodlar += "----------------------";
        //    return metodlar;
        //}

        public static void HataLogYaz(this Exception exception, HataLogYazTuru logYazTuru, HataLogTuru hataLogTuru, string message)
        {
            switch (logYazTuru)
            {
                case HataLogYazTuru.TextFile:
                    Log.Instance.Yaz(message);
                    break;
                case HataLogYazTuru.Database:
                    using (var _uow = new UnitOfWork(new EFContext()))
                    {
                        var tHataLogRepository = _uow.GetRepository<tHataLog>();
                        tHataLog _kayit = new tHataLog
                        {
                            HataLogTuru = hataLogTuru,// farkı türler tanımlanabilir mesela dikkat , önemli değil vb. gibi
                            KullaniciId = KullaniciHelper.Getir("ezdemir").Id,// 1,// kullanıcı tablosundan o anki aktif kullanıcı id si getirilip yazılacak
                            HataDetayi = message
                        };
                        tHataLogRepository.Ekle(_kayit);
                        int process = _uow.DegisiklikleriKaydet(_kayit.KullaniciId);
                    }

                    break;
            }
        }

        public static void HataLogYaz(this Exception exception, HataLogYazTuru logYazTuru, HataLogTuru hataLogTuru, string message, string metod)
        {
            switch (logYazTuru)
            {
                case HataLogYazTuru.TextFile:
                    Log.Instance.Yaz(message + metod);
                    break;
                case HataLogYazTuru.Database:

                    using (var _uow = new UnitOfWork(new EFContext()))
                    {
                        var tHataLogRepository = _uow.GetRepository<tHataLog>();
                        tHataLog _kayit = new tHataLog
                        {
                            HataLogTuru = hataLogTuru,// farkı türler tanımlanabilir mesela dikkat, önemli değil vb. gibi
                            KullaniciId = KullaniciHelper.Getir("ezdemir").Id,// 1,// kullanıcı tablosundan o anki aktif kullanıcı id si getirilip yazılacak
                            HataninOlustuguMetod = metod,
                            HataDetayi = message
                        };
                        tHataLogRepository.Ekle(_kayit);
                        int process = _uow.DegisiklikleriKaydet(_kayit.KullaniciId);
                    }

                    break;
            }
        }

        //public static string GetEnumAciklama(this Enum value)
        //{
        //    FieldInfo fi = value.GetType().GetField(value.ToString());

        //    DescriptionAttribute[] attributes =
        //        (DescriptionAttribute[])fi.GetCustomAttributes(
        //        typeof(DescriptionAttribute),
        //        false);

        //    if (attributes != null &&
        //        attributes.Length > 0)
        //        return attributes[0].Description;
        //    else
        //        return value.ToString();
        //}

        public static string GetExceptionDetailMessage(this Exception exception)
        {
            return
                "\nHatanın Oluştuğu Method\n" + exception.MetodAdi()
                + "\nexception.Message\n" + exception.Message
                + "\nInnerException\n"
                + (exception.InnerException == null ? "" : (exception.InnerException.Message + "\nInnerException.InnerException\n"
                + (exception.InnerException.InnerException == null ? "" : exception.InnerException.InnerException.Message)))
                + "\nStackTrace:\n" + exception.StackTrace;
        }
    }

    public enum HataLogYazTuru

    {
        Database = 1,
        TextFile = 2
    }

   




}

#endregion