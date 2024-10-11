using System.Collections.Generic;

namespace DenemeUygulama.Data.Netsis.RestModels
{
    public class myItemSlips
    {
        public bool? AcikBelgeTahsilat { get; set; }
        
        public bool? BaglantiKontrol { get; set; }
        
        public bool? EPostaGonderilsin { get; set; }
        
        public int? FaturaTip { get; set; }
        public myItemSlipsHeader FatUst { get; set; }
        
        public bool? FiyatSistemineGoreHesapla { get; set; }
        
        public int? InternalObjectAddress { get; set; }
        
        public int? KalemAdedi { get; set; }
        
        public List<myItemSlipLines> Kalems { get; set; }
        
        public bool? KayitliNumaraOtomatikGuncellensin { get; set; }
        
        public bool? KosulluHesapla { get; set; }
        
        public bool? MaliyetTipineGoreHesapla { get; set; }
        
        public string Name { get; set; }
        
        public bool? OtoBolgeFarkIskGetir { get; set; }
        
        public bool? OtoIskontoGetir { get; set; }
        
        public bool? OtomatikCevrimYapilsin { get; set; }
        
        public bool? OtomatikIslemTipiGetir { get; set; }
        
        public bool? OtomatikOdemeKoduGetir { get; set; }
        
        public bool? OtoNakliyeKatSayisiGetir { get; set; }
        
        public bool? OtoVadeGunGetir { get; set; }
        
        public bool? RiskKontrol { get; set; }
        public string Seri { get; set; }
        
        public bool? SeriliHesapla { get; set; }
        
        public string Siralama { get; set; }
        
        public bool? SonNumaraYazilsin { get; set; }
        
        public bool? StokKartinaGoreHesapla { get; set; }
        
        public int? TahsilatKalemAdedi { get; set; }
        
        public bool? TahsilatKayitKullan { get; set; }
    }
}
