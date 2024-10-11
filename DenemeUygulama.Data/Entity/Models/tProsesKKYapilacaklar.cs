using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tProsesKKYapilacaklar : BaseClass
    {
        public string OpKodu { get; set; }
        public string IsEmriNo { get; set; }
        public bool KKYapildiMi { get; set; }
    }

    public class tProsesKKYapilacaklar_Map : EntityTypeConfiguration<tProsesKKYapilacaklar>
    {
        public tProsesKKYapilacaklar_Map()
        {
            ToTable("tProsesKKYapilacaklar");
            HasKey(k => k.Id);

        }
    }


}
