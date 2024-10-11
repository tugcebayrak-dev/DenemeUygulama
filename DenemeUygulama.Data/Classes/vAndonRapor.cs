using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Classes
{
    public class vAndonRapor
    {

        #region Personel Durum
        public string PD_PersonelAdi { get; set; }
        public string PD_IstasyonAdi { get; set; }
        public string PD_ProjeKodu { get; set; }
        public string PD_ProjeAdi { get; set; }
        public string PD_BaslamaTarihi { get; set; }
        public string PD_OperasyonAdi { get; set; }
        public string PD_Durum { get; set; }
        public int PD_DurumID { get; set; }
        public string PD_SicilNo { get; set; }
        public DateTime Tarih { get; set; }





        #endregion


        #region Giriş Yapan Ürünler
        public string GU_StokKodu { get; set; }
        public string GU_StokAdi { get; set; }
        public int GU_Miktar { get; set; }
        public string GU_Plasiyer { get; set; }
        public string GU_GirisTarihi { get; set; }
        #endregion


        #region Sevkiyat Bekleyenler

        public string SB_ProjeKodu { get; set; }
        public string SB_Plasiyer { get; set; }

        #endregion


        #region Reçetesi Olmayanlar

        public string RO_ProjeKodu { get; set; }
        public string RO_Plasiyer { get; set; }

        #endregion


        #region SatınAlma Onayı Bekleyenler

        public string SA_ProjeNo { get; set; }
        public string SA_BelgeNo { get; set; }
        public string SA_Plasiyer { get; set; }
        public string SA_BelgeTarihi { get; set; }


        #endregion


        #region Üretim Durumu

        public string UD_ProjeKodu { get; set; }
        public string UD_ProjeAdi { get; set; }
        public string UD_ProjeSorumlusu { get; set; }
        public string UD_IstenenTeslimSuresi { get; set; }
        public string UD_PlanlananTeslimSuresi { get; set; }
        public int UD_KalanTeslimSuresi { get; set; }
        public string UD_Istasyon { get; set; }
        public string UD_ProjeTasarimDurumu { get; set; }
        public string UD_BilesenDurumu { get; set; }
        public int UD_Sira { get; set; }
        public int UD_DurumId { get; set; }

        #endregion



        #region Talep Siparişleştirme

        public string TS_StokKodu { get; set; }
        public string TS_StokAdi { get; set; }
        public int TS_Miktar { get; set; }
        public string TS_Aciklama { get; set; }

        #endregion



        #region Satın Alma Onay Bekleyenler

        public string SO_BelgeNo { get; set; }
        public string SO_Plasiyer { get; set; }
        public string SO_BelgeTipi { get; set; }
        public string SO_Aciklama { get; set; }

        #endregion


        #region Döviz
        public string DovizTuru { get; set; }
        public string DovizDegeri { get; set; }

        #endregion

    }
}
