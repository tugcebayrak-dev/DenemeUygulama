using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tRapor : BaseClass
    {
        public string RaporYolu { get; set; }
        public string RaporAdi { get; set; }
    }

    public class tRapor_Map : EntityTypeConfiguration<tRapor>
    {
        public tRapor_Map()
        {
            ToTable("tRapor");
            HasKey(k => k.Id);

        }
    }
}
