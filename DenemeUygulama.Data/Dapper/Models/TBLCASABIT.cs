using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Dapper.Models
{
    
    /// <summary>
    /// Bu modelde değişiklik yapıldığı taktirde Scripts/Script
    /// </summary>
    public class TBLCASABIT
    {
        public short SUBE_KODU { get; set; }

        public short ISLETME_KODU { get; set; }

        public string CARI_KOD { get; set; }
    }
}
