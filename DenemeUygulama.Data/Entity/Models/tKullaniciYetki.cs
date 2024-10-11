using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tKullaniciYetki : BaseClass
    {
        public int KullaniciId { get; set; }
        public int ModulId { get; set; }
        public string KullaniciTipAciklama { get; set; } 
        public string ModulTipAciklama { get; set; }
        public string IslemTipleri { get; set; }
        public bool Goruntule { get; set; }
        public bool Ekle { get; set; }
        public bool Guncelle { get; set; }
        public bool Sil { get; set; }
    }
    public class tKullaniciYetki_Map : EntityTypeConfiguration<tKullaniciYetki>
    {
        public tKullaniciYetki_Map()
        {
            HasKey(k => k.Id);
            ToTable("tKullaniciYetki");

        }
    }
}
