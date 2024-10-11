using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Classes
{
    public class vOperasyonKurgu
    {
        public int Id { get; set; }
        public string KurguAdi { get; set; }
        public bool Baslat { get; set; }
        public bool DurusBaslat { get; set; }
        public bool DurusBitir { get; set; }
        public bool Bitir { get; set; }
        public OperasyonKurgu KurguTipi { get; set; }
    }
}
