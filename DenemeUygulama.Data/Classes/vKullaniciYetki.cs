using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Classes
{
   public class vKullaniciYetki
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string ModulAdi { get; set; }
        public string KullaniciAdi { get; set; }
        public int ModulId { get; set; }
        public string KullaniciTipAciklama { get; set; }
        public string ModulTipAciklama { get; set; }
        public string IslemTipleri { get; set; }
        public bool Goruntule { get; set; }
        public bool Ekle { get; set; }
        public bool Guncelle { get; set; }
        public bool Sil { get; set; }
    }
}
