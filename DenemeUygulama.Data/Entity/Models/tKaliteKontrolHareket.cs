using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tKaliteKontrolHareket : BaseClass
    {
        public KaliteKontrolTuru KaliteKontrolTur { get; set; }
        public string FATIRSNO { get; set; }
        public string STOK_KODU { get; set; }
        public string CARIKODU { get; set; }


        public string GrupKodu { get; set; }
        public string OpKodu { get; set; }
        public string IsEmriNo { get; set; }


        public string OlcumKodu { get; set; }
        public int OlcumSira { get; set; }
        public string OlcumAdi { get; set; }
        public string OlcumAciklama { get; set; }
        public string OlcumDegeri { get; set; }
        public string OlcumSonucu { get; set; }
        public string StokKodu { get; set; }
        public string DepartmanKodu { get; set; }
        public string KKAciklama { get; set; }

        public string OlcumSonuc { get; set; }
        public string OlcumYapilanCihaz { get; set; }
        public int PaketAdedi { get; set; }

    }

    public class tKaliteKontrolHareket_Map : EntityTypeConfiguration<tKaliteKontrolHareket>
    {
        public tKaliteKontrolHareket_Map()
        {
            ToTable("tKaliteKontrolHareket");
            HasKey(k => k.Id);

        }
    }
}
