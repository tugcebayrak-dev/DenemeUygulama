using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tTuketilenBilesenListesi : BaseClass
    {
        public string StokKodu { get; set; }
        public string StokSerisi { get; set; }
        public string CikisDepoKodu { get; set; }
        public string GirisDepoKodu { get; set; }
        public string IsEmriNo { get; set; }
        public string RefIsEmriNo { get; set; }
       
        public string OperasyonKodu { get; set; }
        public int Sira { get; set; }

    }

    public class tTuketilenBilesenListesi_Map : EntityTypeConfiguration<tTuketilenBilesenListesi>
    {
        public tTuketilenBilesenListesi_Map()
        {
            HasKey(k => k.Id);
            ToTable("tTuketilenBilesenListesi");
        }
    }
}
