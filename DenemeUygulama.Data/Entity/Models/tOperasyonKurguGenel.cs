using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tOperasyonKurguGenel : BaseClass
    {
        public string OperasyonKodu { get; set; }
        public OperasyonKurgu KurguTipi { get; set; }
        public bool OncekiOpBeklensinMi { get; set; }

    }
    public class tOperasyonKurguGenel_Map : EntityTypeConfiguration<tOperasyonKurguGenel>
    {
        public tOperasyonKurguGenel_Map()
        {
            HasKey(k => k.Id);
            ToTable("tOperasyonKurguGenel");

        }
    }
}
