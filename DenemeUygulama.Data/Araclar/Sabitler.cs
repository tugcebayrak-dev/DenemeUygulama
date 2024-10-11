using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Araclar
{
    public static class Sabitler
    {
        public static string txtFirmaUnvan;
        public static string txtFirmaTel;
        public static string txtFirmaWeb;
        public static string txtFirmaLogoAdi;
        public const string WPF_RAPOR_URL = @"\\192.168.2.14\Netsis\DenemeUygulama\ExcelRaporlar\";
        //public const string WPF_RAPOR_URL = @"\\172.16.33.241\Netsis\DenemeUygulama\ExcelRaporlar\";

        public const string LisansServiceProgramKodu = "07";

        public static string UygulamaDbName = "MakusDB";

        public static int UserId = 1;
        public static string KullaniciAdi = "makus";
        public static string AdSoyad = "MAKUS";


        public static string txtServer;
        public static string txtServerUserName;
        public static string txtServerPass;

        public static string txtSirketUserName;
        public static string txtSirketPass;
        //-------------------------SISTEM-------------------------
        public const string DEFAULT_KEY = "Berka";

    }
}
