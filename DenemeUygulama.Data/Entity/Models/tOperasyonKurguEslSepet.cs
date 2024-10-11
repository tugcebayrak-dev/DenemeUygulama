using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tOperasyonKurguEslSepet : BaseClass
    {
        public int KurguId { get; set; }
        public OperasyonKurgu KurguTipi { get; set; }
        public int OperasyonId { get; set; }
        public string OperasyonKodu { get; set; }

        public bool Baslat { get; set; }
        public int BaslatOncelik { get; set; }

        public bool DurusBaslat { get; set; }
        public int DurusBaslatOncelik { get; set; }

        public bool DurusBitir { get; set; }
        public int DurusBitirOncelik { get; set; }

        public bool Bitir { get; set; }
        public int BitirOncelik { get; set; }
    }

    public class tOperasyonKurguEslSepet_Map : EntityTypeConfiguration<tOperasyonKurguEslSepet>
    {
        public tOperasyonKurguEslSepet_Map()
        {
            HasKey(k => k.Id);
            ToTable("tOperasyonKurguEslSepet");

        }
    }
}
