using System;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
    public abstract class BaseClass
    {
        //[Key] //Özellikler eğer ilgili context üzerinde verilmez ise buradan tanımlanır.
        public int Id { get; set; }
        public DateTime? KayitTarihi { get; set; }
        public bool Silindi { get; set; }
        //public Durum Durum { get; set; }
        public DateTime? SonGuncellenmeTarihi { get; set; }

        public KayitDurumu KayitDurumu { get; set; }
        public string KaydedenKullaniciAdi { get; set; }
        public string GuncelleyenKullaniciAdi { get; set; }

    }
}
