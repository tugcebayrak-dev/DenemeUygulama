using DenemeUygulama.Data.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeUygulama.Data.Contexts
{
    public partial class Context : DbContext
    {
        public Context(string connectionStringName) : base(connectionStringName)
        {

        }
        public DbSet<tKullanici> tKullanici { get; set; }
        //public DbSet<KullaniciYetki> tKullaniciYetki { get; set; }
        //public DbSet<Istasyon> tIstasyon { get; set; }
        //public DbSet<Parametre> tParametre { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new tKullanici_Map());
            //modelBuilder.Configurations.Add(new KullaniciYetki_Map());
            //modelBuilder.Configurations.Add(new Istasyon_Map());
            //modelBuilder.Configurations.Add(new Parametre_Map());

            Database.SetInitializer<Context>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}

