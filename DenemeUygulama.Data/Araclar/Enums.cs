using System.ComponentModel;

namespace DenemeUygulama.Data.Araclar
{
    public class Enums
    {
        #region KAYIT DURUMU
        public enum KayitDurumu
        {
            [Description("Aktif")]
            Aktif = 1,

            [Description("Pasif")]
            Pasif = 2,

            [Description("Silindi")]
            Silindi = 3
        }
        #endregion

        #region SABIT TURU
        public enum SabitTuru
        {
            Parametre = 1,
            Enum = 2
        }
        #endregion
        #region LOG TURU
        public enum LogTuru
        {
            [Description("Eklendi")]
            Eklendi = 1,
            [Description("Güncellendi")]
            Guncellendi = 2,
            [Description("Silindi")]
            Silindi = 3
        }
        #endregion

        #region HATA LOG TURU
        public enum HataLogTuru
        {
            AltYapiHatasi = 1,
            UygulamaHatasi = 2,
            NetsisHatasi = 3
        }
        #endregion

        #region KULLANICI TİPİ
        [DefaultValue(TamYetkili)]
        public enum KullaniciTip
        {
            [Description("Admin")]
            Admin = 1,

            [Description("Tam Yetkili")]
            TamYetkili = 2,

            [Description("Kısıtlı")]
            Kısıtlı = 3,

        }
        #endregion
      
        #region YETKI
        public enum Yetki
        {
            [Description("Admin")]
            Admin = 1,
            [Description("Planlama")]
            Planlama = 2,
            [Description("Üretim")]
            Uretim = 3,
           [Description("Veri Sorumlusu")]
            VeriSorumlusu = 4,
            [Description("Proses Kalite Kontrol")]
            ProsesKaliteKontrol = 5
        }
        #endregion

        #region PLANDURUM
        public enum PlanDurum
        {
            [Description("Yeni Plan")]   //planlama aktif olursa ilk buraya düşecek planlamacı bunları atayacak
            YeniPlanYapilacak = 10,
            [Description("Üretim Bekletiliyor")] // Üretim müdürünün operatorün ekranından kaldırdığı operasyonlar
            PlanDisiBekliyor = 20,
            [Description("Üretime Gönderildi")] // üretim müdürünün özellikle atadığı bekleyen operasyon
            Planlandi = 30,
            [Description("Netsis Otomatik Atama")]   //netsisten otomatik çekilip atama yapılırsa bu şekilde başlayacak //planlama pasif olursa bu olacak
            OtomatikPlan = 40,
            [Description("Üretim Dışı Operasyon")]  //Netsiste kayıtlı operasyon var fakat otomatikte olsa planlıda olsa üretim ekranlarına düşmeyecek  parametrelerden açıklama startwith tanımlanabilsin
            PlanYapilmayacak = 50,
            [Description("Netsisten Silinmiş")]  // işemri veya operasyon netsisten sonlandırılınca veya silinince otomatik üretim ekranından düşecek
            NetsistenSilinmis = 60,
            [Description("Harici Operasyon")]   //netsisten iş emri girilmeden operator harici operasyon açabilecek  // parametrik olabilir ve harici olacak operasyonların açıklaması neyle başlayacak parametresi eklensin
            HariciOperasyon = 70,
            [Description("İş Emri Kapatılmış")]   //netsisten iş emri kapatılınca pasife çeker
            IsEmriKapatilmis = 80,
            [Description("Operasyon Silinmis")]   //netsisten operasyon silinince pasife çeker
            OperasyonSilinmis = 90,
        }
        #endregion

        #region OPERASYON DURUM 
        public enum OperasyonDurum
        {
            [Description("Yapilacak")]
            OperasyonYeni = 10,
            [Description("Devam Ediyor")]
            OperasyonBaslatildi = 20,
            [Description("Bekliyor")]
            OperasyonBekliyor = 30,
            [Description("Bitti")]
            OperasyonBitti = 40,
            [Description("Duraklatildi")]
            Duraklatıldı = 50,
            [Description("BasladiBitmedi")]
            BasladiBitmedi = 60,
            [Description("Kapatilanlar")]
            Kapatilanlar = 70,
            [Description("Silinenler")]
            Silinenler = 80,
            [Description("OpSilinenler")]
            OpSilinenler = 90,

            [Description("Tumu")]
            Tumu = -1,
        }
        public enum ProsesDurum
        {
            [Description("Yapilacak")]
            ProsesYapilacak = 1,           
            [Description("Bitti")]
            ProsesBitti = 2,           
            [Description("Tumu")]
            Tumu = 3,
        }

        public enum USKDurum
        {
            [Description("Yapilacak")]
            USKYapilacak = 1,
            [Description("Bitti")]
            USKBitti = 2,
            [Description("Tumu")]
            USKTumu = 3,
        }
        public enum GirdiDurum
        {

            [Description("Yapilacak")]
           GirdiYapilacak = 1,
            [Description("Bitti")]
            GirdiBitti = 2,
            [Description("Tumu")]
            Tumu = 3,
        }
        #endregion

        #region OPERASYON KURGU 
        public enum OperasyonKurgu
        {
            [Description("UAK")]
            UAK = 1,
            [Description("FASON")]
            FASON = 2,
            [Description("DAT")]
            DAT = 3,
            [Description("ETIKET")]
            ETIKET = 4,
            [Description("REZERVASYON")]
            REZERVASYON = 5,
            [Description("ARA URETIM")]
            ARAURETIM = 6,
            [Description("ALTERNATIF HAMMADDE")]
            ALTERNATIFURETIM = 7,
            [Description("SERILOT")]
            SERILOT = 8,
            [Description("BILGILENDIRME")]
            BILGILENDIRME = 9,
            [Description("PROCESS KALITE KONTROL")]
            PROCESSKALITEKONTROL = 10,
            [Description("URETIM SONU KAYDI")]
            URETIMSONUKAYDI = 11,
            [Description("ONAY")]
            ONAY = 12,
            [Description("GIRDI KALITE KONTROL")]
            GIRDIKALITEKONTROL = 13,
            [Description("OPERASYON GENEL KURGUSU")]
            OPERASYONGENELKURGUSU = 14,
            [Description("OPERASYON BITIS ETIKETI")]
            OPERASYONBITISETIKETI = 15,
            [Description("OPERASYON BASLATMA ETIKETI")]
            OPERASYONBASLATMAETIKETI = 16,
            [Description("BILESEN TUKETME KURGUSU")]
            BILESENTUKETMEKURGUSU = 17,

        }
        #endregion
        #region ETIKET
        public enum EtiketTipi
        {
            [Description("KULLANICI ETIKETI")]
            KULLANICIETIKETI = 1,
            [Description("OPERASYON BASLATMA ETIKETI")]
            OPERASYONBASLATMAETIKETI = 2,
            [Description("OPERASYON BITIS ETIKETI")]
            OPERASYONBITISETIKETI = 3,
            [Description("GENEL")]
            GENEL = 4,
            [Description("GIRDI KALITE KONTROL ETIKETI-KABUL")]
            GIRDIKALITEKONTROLETIKETIKABUL = 5,
            [Description("GIRDI KALITE KONTROL ETIKETI-SARTLI KABUL")]
            GIRDIKALITEKONTROLETIKETISARTLIKABUL = 6,
            [Description("GIRDI KALITE KONTROL ETIKETI-RED")]
            GIRDIKALITEKONTROLETIKETIRED = 7,
            [Description("PROSES KALITE KONTROL ETIKETI-KABUL")]
            PROSESKALITEKONTROLETIKETIKABUL = 8,
            [Description("PROSES KALITE KONTROL ETIKETI-SARTLI KABUL")]
            PROSESKALITEKONTROLETIKETISARTLIKABUL = 9,
            [Description("PROSES KALITE KONTROL ETIKETI-RED")]
            PROSESKALITEKONTROLETIKETIRED = 10,
            [Description("OPERASYON BEKLETME ETIKETI")]
            OPERASYONBEKLETMEETIKETI = 11,
        }
        #endregion
        #region MODUL TİPİ
        public enum ModulTipi
        {
            [Description("KULLANICILAR")]
            KULLANICILAR = 0,

            [Description("OPERASYONLAR")]
            OPERASYONLAR = 1,

            [Description("ISTASYONLAR")]
            ISTASYONLAR = 2,

            [Description("ARIZALAR")]
            ARIZALAR = 3,

            [Description("RECETELER")]
            RECETELER = 4,

            [Description("TEZGAH")]
            TEZGAH = 5,
            [Description("PLANLAMA")]
            PLANLAMA = 6         

        }
        #endregion


        #region PLANLAMA LOG TİPİ
        public enum PlanlamaLogTipi
        {
            [Description("BASLAT")]
            BASLAT = 1,
            [Description("DURUSBASLAT")]
            DURUSBASLAT = 2,
            [Description("DURUSBITIR")]
            DURUSBITIR = 3,
            [Description("BITIR")]
            BITIR = 4,
            [Description("UAK")]
            UAK = 6,
            [Description("FASON")]
            FASON = 7,
            [Description("DAT")]
            DAT = 8,
            [Description("ETIKET")]
            ETIKET = 9,
            [Description("REZERVASYON")]
            REZERVASYON = 10,
            [Description("ARA URETIM")]
            ARAURETIM = 11,
            [Description("ALTERNATIF HAMMADDE")]
            ALTERNATIFURETIM = 12,
            [Description("SERILOT")]
            SERILOT = 13,
            [Description("BILGILENDIRME")]
            BILGILENDIRME = 14,
            [Description("PROCESS KALITE KONTROL")]
            PROCESSKALITEKONTROL = 15,
            [Description("URETIM SONU KAYDI")]
            URETIMSONUKAYDI = 16,
            [Description("ONAY")]
            ONAY = 17,
            [Description("GIRDI KALITE KONTROL")]
            GIRDIKALITEKONTROL = 18,
            [Description("OPERASYONBITISETIKETI")]
            OPERASYONBITISETIKETI = 19,
            [Description("PERSONELDURDUR")]
            PERSONELDURDUR = 20,
            [Description("PERSONELDEVAM")]
            PERSONELDEVAM = 21,
            [Description("BILESEN TUKETME KURGUSU")]
            BILESENTUKETMEKURGUSU = 22,





        }
        #endregion


        #region İŞLEM TİPİ
        public enum IslemTipi
        {
            [Description("Goruntule")]
            Goruntule = 0,

            [Description("Ekle")]
            Ekle = 1,

            [Description("Guncelle")]
            Guncelle = 2,

            [Description("Sil")]
            Sil = 3


        }
        #endregion


        #region RaporIslemTipi
        public enum RaporIslemTipi
        {
            [Description("Yazdır")]
            Yazdır = 1,

            [Description("Düzenle")]
            Duzenle = 2,

            [Description("Önizle")]
            Onizle = 3,
        }

        #endregion

        public enum DevMesajDelay
        {
            [Description("10SN")]
            Uzun = 10000,

            [Description("5SN")]
            Orta = 5000,

            [Description("2SN")]
            Kisa = 2000
        }

        public enum SonucTuru
        {
            [Description("Null")]
            Null = -1,
            [Description("Başarılı")]
            Basarili = 1,

            [Description("Hata")]
            Hata = 2,

            [Description("Bilgi")]
            Bilgi = 3
        }
        public enum PersonelDurumu
        {
            [Description("DevamEdiyor")]
            DevamEdiyor = 1,
            [Description("Durduruldu")]
            Durduruldu = 2,

        }


        #region KaliteKontrolTur
        public enum KaliteKontrolTuru
        {
            [Description("ProsesKaliteKontrol")]
            ProsesKaliteKontrol = 1,
            [Description("GirdiKaliteKontrol")]
            GirdiKaliteKontrol = 2,
        
        }
        #endregion


    }
}
