using DenemeUygulama.Data.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
    public partial class IslemLog : BaseClass
    {
        public int KaynakTabloId { get; set; }
        public LogTuru LogTuru { get; set; }
        public string TabloAdi { get; set; }
        public string JsonDeger { get; set; }
        public int KullaniciId { get; set; }
    }
    public class IslemLog_Map : EntityTypeConfiguration<IslemLog>
    {
        public IslemLog_Map()
        {
            HasKey(t => t.Id);
            ToTable("IslemLog");
        }
    }
}