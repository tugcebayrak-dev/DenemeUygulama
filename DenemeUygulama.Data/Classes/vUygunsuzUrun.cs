using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Classes
{
   public class vUygunsuzUrun
    {
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string OpKodu { get; set; }
        public string IstasyonKodu { get; set; }
        public string IstasyonAdi { get; set; }
        public KaliteKontrolTuru KaliteKontrolTur  { get; set; }

        public string IrsaliyeNo { get; set; }
        public string CariKodu { get; set; }
        public string CariAdi { get; set; }
        public string IsEmriNo { get; set; }
        public DateTime ? KayitTarihi { get; set; }
        public string KaydedenKullaniciAdi { get; set; }









    }
}
