using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tUretimSonuKaydiYapilacaklar : BaseClass
    {
        public string IsEmriNo { get; set; }
        public string MamulKodu { get; set; }
        public string DepoKodu { get; set; }
        public int Miktar { get; set; }
        public string ProjeKodu { get; set; }
        public bool UretildiMi { get; set; }
        public string CikisDepo { get; set; }


    }

    public class tUretimSonuKaydiYapilacaklar_Map : EntityTypeConfiguration<tUretimSonuKaydiYapilacaklar>
    {
        public tUretimSonuKaydiYapilacaklar_Map()
        {
            ToTable("tUretimSonuKaydiYapilacaklar");
            HasKey(k => k.Id);

        }
    }
}
