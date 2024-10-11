using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tKullanici : BaseClass
    {
      
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

    
        public bool AktifCalisiyorMu { get; set; } = false;

        public int EsZamanliMaxOperasyonSayisi { get; set; } = 1;

        public ICollection<tHataLog> tHataLog { get; set; } = new List<tHataLog>();
        public ICollection<tLog> tLog { get; set; } = new List<tLog>();

        public string SicilNo { get; set; }
        public string BarkodNo { get; set; }



    }
    public class tKullanici_Map : EntityTypeConfiguration<tKullanici>
    {
        public tKullanici_Map()
        {
            HasKey(k => k.Id);
            ToTable("tKullanici");

        }
    }

}
