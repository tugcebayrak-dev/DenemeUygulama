using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.Models
{
    public class tPersonelTezgahHareket : BaseClass
    {
        public int planlamaHareketId { get; set; }
        public int personelTezgahEslesmeHareketId { get; set; }

    }


    public class tPersonelTezgahHareket_Map : EntityTypeConfiguration<tPersonelTezgahHareket>
    {
        public tPersonelTezgahHareket_Map()
        {
            HasKey(k => k.Id);
            ToTable("tPersonelTezgahHareket");

        }
    }

}
