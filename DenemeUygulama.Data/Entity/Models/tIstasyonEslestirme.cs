using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tIstasyonEslestirme : BaseClass
    {
        public string IstasyonKodu { get; set; }
        public string IstasyonAdi { get; set; }
        public string OperasyonKodu { get; set; }
        public string OperasyonAdi { get; set; }
        public string TezgahKodu { get; set; }
        public string TezgahAdi { get; set; }
    }

    public class tIstasyonEslestirme_Map : EntityTypeConfiguration<tIstasyonEslestirme>
    {
        public tIstasyonEslestirme_Map()
        {
            HasKey(k => k.Id);
            ToTable("tIstasyonEslestirme");

        }
    }
}
