using System.Data.Entity.ModelConfiguration;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tHataLog : BaseClass
    {
        public HataLogTuru HataLogTuru { get; set; }
        public int KullaniciId { get; set; }
        public string HataninOlustuguMetod { get; set; }
        public string HataDetayi { get; set; }

        public virtual tKullanici tKullanici { get; set; }
    }
    public class tHataLog_Map : EntityTypeConfiguration<tHataLog>
    {
        public tHataLog_Map()
        {
            HasKey(k => k.Id);
            ToTable("tHataLog");
        }
    }

}
