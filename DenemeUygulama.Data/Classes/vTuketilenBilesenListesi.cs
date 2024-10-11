using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Classes
{
    public class vTuketilenBilesenListesi
    {
        
        public string StokKodu { get; set; }
        public string StokSerisi { get; set; }
        public string CikisDepoKodu { get; set; }
        public string GirisDepoKodu { get; set; }
        public string IsEmriNo { get; set; }
        public string OperasyonKodu { get; set; }
        public int Miktar { get; set; }
        public string RefIsEmriNo { get; set; }
        public int Sira { get; set; }


    }
}
