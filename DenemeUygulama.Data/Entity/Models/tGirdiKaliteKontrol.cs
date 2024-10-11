using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tGirdiKaliteKontrol : BaseClass
    {
        public string FATIRSNO { get; set; }
        public string STOK_KODU { get; set; }
        public string CARIKODU { get; set; }
        public string GrupKodu { get; set; }
        public string BelgeYolu { get; set; }
        public byte[] PDFData { get; set; }

    }
    public class tGirdiKaliteKontrol_Map : EntityTypeConfiguration<tGirdiKaliteKontrol>
    {
        public tGirdiKaliteKontrol_Map()
        {
            ToTable("tGirdiKaliteKontrol");
            HasKey(k => k.Id);

        }
    }
}
