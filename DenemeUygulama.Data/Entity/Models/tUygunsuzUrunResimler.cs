using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
   public class tUygunsuzUrunResimler : BaseClass

    {
        public int UygunsuzUrunId { get; set; }
        public string DosyaAdi  { get; set; }
        public string DosyaTipi { get; set; }
        public string DosyaYolu { get; set; }
        public byte[] Data { get; set; }


    }
    public class tUygunsuzUrunResimler_Map : EntityTypeConfiguration<tUygunsuzUrunResimler>
    {
        public tUygunsuzUrunResimler_Map()
        {
            ToTable("tUygunsuzUrunResimler");
            HasKey(k => k.Id);

        }
    }

}
