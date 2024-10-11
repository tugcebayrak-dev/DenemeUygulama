using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tProsesKaliteKontrol : BaseClass
    {

        public string OpKodu { get; set; }
        public string IsEmriNo { get; set; }
        public string GrupKodu { get; set; }
        public string BelgeYolu { get; set; }
        public byte[] PDFData { get; set; }
    }
    public class tProsesKaliteKontrol_Map : EntityTypeConfiguration<tProsesKaliteKontrol>
    {
        public tProsesKaliteKontrol_Map()
        {
            ToTable("tProsesKaliteKontrol");
            HasKey(k => k.Id);

        }
    }
}
