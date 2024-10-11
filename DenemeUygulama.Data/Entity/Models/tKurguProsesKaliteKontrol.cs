using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Entity.Models
{
   public class tKurguProsesKaliteKontrol : BaseClass
    {
        public bool IslemiDurdur { get; set; }
        public bool IslemiHavuzaAt { get; set; }
        public bool ProsesKullaniciGirisEkrani { get; set; }
    }
    public class tKurguProsesKaliteKontrol_Map : EntityTypeConfiguration<tKurguProsesKaliteKontrol>
    {
        public tKurguProsesKaliteKontrol_Map()
        {
            HasKey(k => k.Id);
            ToTable("tKurguProsesKaliteKontrol");
        }
    }
}
