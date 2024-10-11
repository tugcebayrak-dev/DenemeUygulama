using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Classes
{
    public class vEtiket
    {
        public string Tanimi { get; set; }
        public byte[] EtiketData { get; set; }
        public bool VarsayilanEtiketMi { get; set; }
        public string DosyaUzantisi { get; set; }
        public string EtiketTipi { get; set; }
        public int Id { get; set; }
        public EtiketTipi EtiketTipiEnum { get; set; }
    }
}
