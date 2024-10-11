using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Entity.Models
{
   public class tModul : BaseClass
    {
        public string ModulAdi { get; set; }
    }

    public class tModul_Map : EntityTypeConfiguration<tModul>
    {
        public tModul_Map()
        {
            HasKey(k => k.Id);
            ToTable("tModul");
        }
    }
}
