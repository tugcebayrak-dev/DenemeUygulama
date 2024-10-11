using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
   public class tEtiket : BaseClass
    {
        public string Tanimi { get; set; }
        public byte[] EtiketData { get; set; }
        public bool VarsayilanEtiketMi { get; set; }
        public string DosyaUzantisi { get; set; }
        public string EtiketTipi { get; set; }
        public EtiketTipi EtiketTipiEnum { get; set; }
    }

    public class tEtiket_Map : EntityTypeConfiguration<tEtiket>
    {
        public tEtiket_Map()
        {
            HasKey(k => k.Id);
            ToTable("tEtiket");

        }
    }
}
