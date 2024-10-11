using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{

    public class tPlanlama : BaseClass
    {

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
        public string IstasyonAdi { get; set; }
        public string ImalatNo { get; set; }



        public OperasyonDurum SonDurum { get; set; }
        public string SonDurumText { get; set; }

        public DateTime? SonBaslamaTarihi { get; set; }
        public DateTime? SonBekletmeTarihi { get; set; }
        public int? SonKullaniciId { get; set; }
        public string SonKullanici { get; set; }
        public DateTime? OperasyonuIlkBaslatmaTarihi { get; set; }
        public DateTime? OperasyonBitisTarihi { get; set; }
        public int KisiSayisi { get; set; } = 0;
        public PlanDurum? PlanDurum { get; set; }
        public string PlanDurumText { get; set; }
        public int TahminiSure { get; set; }
        public int HarcananSure { get; set; }
        public int BeklenenSure { get; set; } = 0;

        public string SiparisNumarasi { get; set; }
        public int SiparisSira { get; set; }
        public string CariKodu { get; set; }
        public string CariAdi { get; set; }
        public int DepoKodu { get; set; }
        public int YapilanMiktar { get; set; }
        public int KalanMiktar { get; set; }
        public int YapılanMiktar { get; set; }

        public string ProjeNumarasi { get; set; }
        public DateTime? TeslimTarihi { get; set; }
        //public string ProjeNumarasi2 { get; set; }
        public string IsEmriAciklama { get; set; }
        public DateTime? OperasyonPlanBaslangicTarihi { get; set; }
        public DateTime? OperasyonPlanBitisTarihi { get; set; }
        public bool SureHesaplandiMi { get; set; }

    }
    public class tPlanlama_Map : EntityTypeConfiguration<tPlanlama>
    {
        public tPlanlama_Map()
        {
            ToTable("tPlanlama");
            HasKey(k => k.Id);

        }
    }
}
