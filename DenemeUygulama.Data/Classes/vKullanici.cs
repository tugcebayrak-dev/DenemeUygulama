using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Classes
{
   public  class vKullanici
    {
        public int Id { get; set; }
        public string KullaniciAdSoyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSifresi { get; set; }
        
        public Yetki Yetki { get; set; }
        public string YetkiText { get; set; }
        public string NetsisIstasyonKodu { get; set; }
        public string NetsisIstasyonAdi { get; set; }
        public bool Baslatabilir { get; set; }
        public bool Bekletebilir { get; set; }
        public bool Bitirebilir { get; set; }
        public string SicilNo { get; set; }

        public bool AktifCalisiyorMu { get; set; } = false;

        public int EsZamanliMaxOperasyonSayisi { get; set; } = 1;

        public DateTime? VekaletBaslangicTarihi { get; set; }
        public DateTime? VekaletBitisTarihi { get; set; }
    }
}
