using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tPlanlamaHareket: BaseClass
    {
        public int SipariNumarasi { get; set; }
        public int SiparisSira { get; set; }
        public string CariKodu { get; set; }
        public string CariAdi { get; set; }
        public string IsEmriNo { get; set; }
        public string RefIsEmriNo { get; set; }
        public string MamulKodu { get; set; }
        public string StokAdi { get; set; }
        public string ImalatNo { get; set; }
        public string OperasyonNo { get; set; }
        public string OperasyonKodu { get; set; }
        public string OperasyonAdi { get; set; }
        public string OperasyonAciklama { get; set; }
        public decimal OperasyonSiraNo { get; set; }
        public string IstasyonKodu { get; set; }
        public string IstasyonAdi { get; set; }
        public int Miktar { get; set; }
        public OperasyonDurum SonDurum { get; set; }
        public string SonDurumText { get; set; }
        public int? OperasyonId { get; set; }


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
        public string DurdurulmaSebep { get; set; }
        public string DurdurulmaAciklama { get; set; }
        public PlanlamaLogTipi tip { get; set; }
        public int YapılanMiktar { get; set; }
        public int KalanMiktar { get; set; }
        public int YapilanMiktar { get; set; }


    }

    public class tPlanlamaHareket_Map : EntityTypeConfiguration<tPlanlamaHareket>
    {
        public tPlanlamaHareket_Map()
        {
            ToTable("tPlanlamaHareket");
            HasKey(k => k.Id);

        }
    }
}
