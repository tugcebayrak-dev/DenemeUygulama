using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tUygunsuzUrun : BaseClass
    {
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string IrsaliyeNo { get; set; }
        public string CariKodu { get; set; }
        public string CariAdi { get; set; }
        public string UygunsuzlukSebebi { get; set; }
        public string YapilacakIslemler { get; set; }
        
        public string OpKodu { get; set; }
        public string IstasyonKodu { get; set; }
        public string IstasyonAdi { get; set; }
        public int Miktar { get; set; }
        public string RefNo { get; set; }
        public bool UySebepProses { get; set; }
        public bool UySebepOperator { get; set; }
        public bool UySebepMakina { get; set; }
        public bool UySebepMalzeme { get; set; }
        public string UySebepAciklama { get; set; }
        public int UyTespitEdenKullaniciId { get; set; }

        public string UyTespitEdenKullanici { get; set; }
        public string UyTespitEdenKullaniciIstasyon { get; set; }
        public bool IncelemeProses { get; set; }
        public bool IncelemeOperator { get; set; }
        public bool IncelemeMakina { get; set; }
        public bool IncelemeMalzeme { get; set; }
        public string IncelemeAciklama{ get; set; }
        public KaliteKontrolTuru KaliteKontrolTur { get; set; }
        public string IsEmriNo { get; set; }
        public int Sira { get; set; }

    }
    public class tUygunsuzUrun_Map : EntityTypeConfiguration<tUygunsuzUrun>
    {
        public tUygunsuzUrun_Map()
        {
            ToTable("tUygunsuzUrun");
            HasKey(k => k.Id);

        }
    }
}
