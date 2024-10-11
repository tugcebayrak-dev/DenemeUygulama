using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tTezgahPersonelEslestirme : BaseClass
    {
        public string OperasyonKodu { get; set; }
        public string OperasyonNo { get; set; }

        public string PersonelSicilNo { get; set; }
        public string KullaniciAdSoyad { get; set; }

        public string IsEmriNo { get; set; }
        public string TezgahKodu { get; set; }
        public string TezgahAdi { get; set; }
        public string IstasyonKodu { get; set; }
        public string IstasyonAdi { get; set; }

        public string IslemBaslatanKullaniciSicil { get; set; }
        public int planlamaId { get; set; }
        public PersonelDurumu personelDurum { get; set; }
        public DateTime? PersonelDurmaTarih { get; set; }
        public DateTime? PersonelBaslamaTarih { get; set; }
        public string PersonelDurusSebebi { get; set; }




    }

    public class tTezgahPersonelEslestirme_Map : EntityTypeConfiguration<tTezgahPersonelEslestirme>
    {
        public tTezgahPersonelEslestirme_Map()
        {
            HasKey(k => k.Id);
            ToTable("tTezgahPersonelEslestirme");

        }
    }
}
