using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tTezgah : BaseClass
    {
        public string TezgahKodu { get; set; }
        public string TezgahAdi { get; set; }
        public string IstasyonKodu { get; set; }
    }

    public class tTezgah_Map : EntityTypeConfiguration<tTezgah>
    {
        public tTezgah_Map()
        {
            HasKey(k => k.Id);
            ToTable("tTezgah");

        }
    }
}
