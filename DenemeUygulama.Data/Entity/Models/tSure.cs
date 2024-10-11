using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tSure : BaseClass
    {
        public string IsEmriNo { get; set; }
        public string OperasyonKodu { get; set; }
        public int? OperasyonId { get; set; }
        public int ? ToplamSure { get; set; }
        public int? DurdurulmaSure { get; set; }
        public string DurdurulmaSebep { get; set; }

    }
    public class tSure_Map : EntityTypeConfiguration<tSure>
    {
        public tSure_Map()
        {
            ToTable("tSure");
            HasKey(k => k.Id);

        }
    }
}
