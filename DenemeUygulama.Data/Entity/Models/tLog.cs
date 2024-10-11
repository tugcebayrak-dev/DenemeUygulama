using System;
using System.Data.Entity.ModelConfiguration;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tLog : BaseClass
    {
        public int KaynakId { get; set; }
        public int KullaniciId { get; set; }
        public LogTuru LogTuru { get; set; }
        public string TabloAdi { get; set; }
        public string Kolonlar { get; set; }
        public string Degerler { get; set; }
        public DateTime Tarih { get; set; }

        public virtual tKullanici tKullanici { get; set; }
    }
    public class tLog_Map : EntityTypeConfiguration<tLog>
    {
        public tLog_Map()
        {
            ToTable("tLog");
            HasKey(k => k.Id);

        }
    }
}
