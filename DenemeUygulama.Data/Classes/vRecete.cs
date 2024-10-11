using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Classes
{
  public  class vRecete
    {
        public string MamulKodu { get; set; }
        public string HammaddeKodu { get; set; }
        public decimal Miktar { get; set; }
        public string Aciklama { get; set; }
        public string IstasyonKodu { get; set; }
        public string IstasyonIsim { get; set; }
        public string OperasyonKodu { get; set; }
        public string OperasyonIsim { get; set; }
        public string OpBil { get; set; }
        public string StokAdi { get; set; }
        public string DepoIsim { get; set; }



    }
}
