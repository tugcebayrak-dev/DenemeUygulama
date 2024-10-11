using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Classes
{
    public class vKaliteKontrol
    {
        public string FATIRSNO { get; set; }
        public string STOK_KODU { get; set; }
        public string CARIKODU { get; set; }


        public string GrupKodu { get; set; }
        public string OpKodu { get; set; }
        public string IsEmriNo { get; set; }

        public string BelgeYolu { get; set; }
        public byte[] PDFData { get; set; }



    }
}
