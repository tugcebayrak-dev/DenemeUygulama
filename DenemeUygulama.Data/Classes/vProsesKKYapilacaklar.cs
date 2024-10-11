using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Classes
{
    public class vProsesKKYapilacaklar
    {
        public string OpKodu { get; set; }
        public string IsEmriNo { get; set; }
        public string IsEmriAciklama { get; set; }
        public string StokKodu { get; set; }
        public string RefIsEmriNo { get; set; }
        public string StokAdi { get; set; }

        public bool KKYapildiMi { get; set; }   
        public int Id { get; set; }

    }
}
