using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Classes
{
    public class vKullaniciVekil
    {
        public string KullaniciSicilNo { get; set; }
        public string VekilKullaniciSicilNo { get; set; }
        public DateTime? VekaletBaslangicTarihi { get; set; }
        public DateTime? VekaletBitisTarihi { get; set; }
    }
}
