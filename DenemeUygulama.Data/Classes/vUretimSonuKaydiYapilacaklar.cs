using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Classes
{
   public class vUretimSonuKaydiYapilacaklar
    {
        public int Id { get; set; }
        public string IsEmriNo { get; set; }
        public string RefIsEmriNo { get; set; }
        public string MamulKodu { get; set; }
        public string DepoKodu { get; set; }
        public int Miktar { get; set; }
        public string ProjeKodu { get; set; }
        public bool UretildiMi { get; set; }
        public string CikisDepo { get; set; }
        public string MamulAdi { get; set; }
        public string SonDurum { get; set; }

    }
}
