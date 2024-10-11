using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tOperasyonKurgu : BaseClass
    {
        public string KurguAdi { get; set; }
        public OperasyonKurgu KurguTipi { get; set; }
    }
    public class tOperasyonKurgu_Map : EntityTypeConfiguration<tOperasyonKurgu>
    {
        public tOperasyonKurgu_Map()
        {
            HasKey(k => k.Id);
            ToTable("tOperasyonKurgu");

        }
    }
}
