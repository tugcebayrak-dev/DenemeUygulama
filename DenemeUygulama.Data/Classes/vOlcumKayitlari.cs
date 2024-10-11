using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Classes
{
    public class vOlcumKayitlari
    {
        public string OlcumKodu { get; set; }
        public int OlcumSira { get; set; }
        public string OlcumAdi { get; set; }    
        public string OlcumAciklama { get; set; }
        public string OlcumDegeri { get; set; }
        public string OlcumSonucu { get; set; }
        public string GrupKodu { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }

        public string DepartmanKodu { get; set; }
        public string OpKodu { get; set; }
        public string IrsaliyeNo { get; set; }
        public string IsEmriNo { get; set; }
        public string KKAciklama { get; set; }
        public int ProsID { get; set; }

        public string OlcumSonuc { get; set; }
        public string CariKodu { get; set; }
        public string OlcumYapilanCihaz { get; set; }
        public string GrupKoduAciklama { get; set; }

        public int Sira { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int PartiAdedi { get; set; }










    }
}
