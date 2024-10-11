using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Classes
{
    public class vOperasyonKurguEslestirme
    {
        public int KurguId { get; set; }
        public int OperasyonId { get; set; }
        public OperasyonKurgu KurguTipi { get; set; }

        public string OperasyonNo { get; set; }
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
}
