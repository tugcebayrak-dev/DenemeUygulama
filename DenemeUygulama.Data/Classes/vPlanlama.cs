using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Classes
{
   public class vPlanlama
    {
        public int Id { get; set; }
        
        public string IsEmriNo { get; set; }
        public string RefIsEmriNo { get; set; }
        public string MamulKodu { get; set; }
        public string HamKodu { get; set; }
        public int Miktar { get; set; }
        public string OperasyonNo { get; set; }
        public string OperasyonKodu { get; set; }
        public string OperasyonAdi { get; set; }
        public string OperasyonAciklama { get; set; }

        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string IstasyonKodu { get; set; }
        public OperasyonDurum SonDurum { get; set; }
        public string IstasyonAdi { get; set; }
        public int DepoKodu { get; set; }
        public string SiparisNumarasi { get; set; }
        public string CariKodu { get; set; }
        public string CariAdi { get; set; }
        public int TahminiSure { get; set; }
        public int HarcananSure { get; set; }

        public int YapilanMiktar { get; set; }
        public int KalanMiktar { get; set; }
        public int BeklenenSure { get; set; } = 0;
        public DateTime? TeslimTarihi { get; set; }
        public DateTime? OperasyonPlanBaslangicTarihi { get; set; }
        public DateTime? OperasyonPlanBitisTarihi { get; set; }
        public DateTime? OperasyonuIlkBaslatmaTarihi { get; set; }
        public string DurdurulmaSebep { get; set; }
        public string DurdurulmaAciklama { get; set; }
        public string IsEmriAciklama { get; set; }
        public string ProjeNumarasi { get; set; }
        public string GecenSure { get; set; }

        public string DurdurulmaGecenSure { get; set; }
        public int CalisanKisiSayisi { get; set; }
        public string GecenDakika { get; set; }
        public string DurdurulmaDakika { get; set; }
        public string Personeller { get; set; }





    }
}
