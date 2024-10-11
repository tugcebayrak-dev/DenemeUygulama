using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tOperasyon : BaseClass
    {
        public string Uniq { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string OperasyonNo { get; set; }
        public string OperasyonAdi { get; set; }
        public string OperasyonAciklama { get; set; }
        public string IstasyonKodu { get; set; }
        public bool SonOperasyonMu { get; set; }

        //public string Alan6 { get; set; }  //migrations->configuratiuns içinde AutomaticMigrationDataLossAllowed = true olursa Update-Database yapınca bu alanı direk siler tehlikelidir veri kaybı olabilir.

        // İlişkiler
        //public ICollection<_Brk_Prj_tOrnekModel3> tOrnekModel3 { get; set; } = new List<_Brk_Prj_tOrnekModel3>();
    }
    public class tOperasyon_Map : EntityTypeConfiguration<tOperasyon>
    {
        public tOperasyon_Map()
        {
            HasKey(k => k.Id);
            ToTable("tOperasyon");
        }
    }
}
