using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Entity.Models
{
   public class tKullaniciVekil : BaseClass
    {
        public string KullaniciSicilNo { get; set; }
        public string VekilKullaniciSicilNo { get; set; }
        public DateTime? VekaletBaslangicTarihi { get; set; }
        public DateTime? VekaletBitisTarihi { get; set; }
    }
    public class tKullaniciVekil_Map : EntityTypeConfiguration<tKullaniciVekil>
    {
        public tKullaniciVekil_Map()
        {
            HasKey(k => k.Id);
            ToTable("tKullaniciVekil");

        }
    }

}
