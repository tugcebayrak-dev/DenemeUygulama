using DenemeUygulama.Data.Entity.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DenemeUygulama.Data.Entity.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("DenemeUygulamaConnectionName")
        {
        }

        //farklı bir veritabanına bağlanmak için connectionstring name gönderebilirsiniz (web.config veya app.config deki connectionstring->name)
        public EFContext(string _connectionStringName) : base(_connectionStringName)
        {

        }

        // public DbSet<tSabit> tSabit { get; set; }
        public DbSet<tLog> tLog { get; set; }
        public DbSet<tHataLog> tHataLog { get; set; }
        public DbSet<tKullanici> tKullanici { get; set; }
        public DbSet<tOperasyon> tOperasyon { get; set; }
        public DbSet<tPlanlama> tPlanlama { get; set; }

        public DbSet<tOperasyonKurgu> tOperasyonKurgu { get; set; }
        ////****PLANLAMA****/////
        public DbSet<tPlanlamaHareket> tPlanlamaHareket { get; set; }
        public DbSet<tOperasyonKurguEslestirme> tOperasyonKurguEslestirme { get; set; }

        public DbSet<tOperasyonKurguEslSepet> tOperasyonKurguEslSepet { get; set; }
        public DbSet<tIstasyonEslestirme> tIstasyonEslestirme { get; set; }

        public DbSet<tTezgah> tTezgah { get; set; }

        public DbSet<tEtiket> tEtiket { get; set; }
        public DbSet<tRapor> tRapor { get; set; }

        public DbSet<tOperasyonKurguGenel> tOperasyonKurguGenel { get; set; }
        public DbSet<tKullaniciVekil> tKullaniciVekil { get; set; }

        public DbSet<tUretimSonuKaydiYapilacaklar> tUretimSonuKaydiYapilacaklar { get; set; }
        public DbSet<tProsesKKYapilacaklar> tProsesKKYapilacaklar { get; set; }
        public DbSet<tModul> tModul { get; set; }
        public DbSet<tKullaniciYetki> tKullaniciYetki { get; set; }
        public DbSet<tTezgahPersonelEslestirme> tTezgahPersonelEslestirme { get; set; }
        public DbSet<tPersonelTezgahHareket> tPersonelTezgahHareket { get; set; }
        public DbSet<tGirdiKaliteKontrol> tGirdiKaliteKontrol { get; set; }
        public DbSet<tProsesKaliteKontrol> tProsesKaliteKontrol { get; set; }
        public DbSet<tKaliteKontrolHareket> tKaliteKontrolHareket { get; set; }
        public DbSet<tKurguProsesKaliteKontrol> tKurguProsesKaliteKontrol { get; set; }
        public DbSet<tTuketilenBilesenListesi> tTuketilenBilesenListesi { get; set; }
        public DbSet<tSure> tSure { get; set; }
        public DbSet<tUygunsuzUrun> tUygunsuzUrun { get; set; }
        public DbSet<tUygunsuzUrunResimler> tUygunsuzUrunResimler { get; set; }









        //model olarak eklenen sınıflar burada set edilir.



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new tKullanici_Map());
            modelBuilder.Configurations.Add(new tLog_Map());
            modelBuilder.Configurations.Add(new tOperasyon_Map());
            modelBuilder.Configurations.Add(new tHataLog_Map());
            modelBuilder.Configurations.Add(new tPlanlamaHareket_Map());
            modelBuilder.Configurations.Add(new tPlanlama_Map());
            modelBuilder.Configurations.Add(new tOperasyonKurguEslestirme_Map());
            modelBuilder.Configurations.Add(new tOperasyonKurguEslSepet_Map());
            modelBuilder.Configurations.Add(new tIstasyonEslestirme_Map());
            modelBuilder.Configurations.Add(new tTezgah_Map());
            modelBuilder.Configurations.Add(new tRapor_Map());
            modelBuilder.Configurations.Add(new tEtiket_Map());
            modelBuilder.Configurations.Add(new tOperasyonKurguGenel_Map());
            modelBuilder.Configurations.Add(new tKullaniciVekil_Map());
            modelBuilder.Configurations.Add(new tUretimSonuKaydiYapilacaklar_Map());
            modelBuilder.Configurations.Add(new tProsesKKYapilacaklar_Map());
            modelBuilder.Configurations.Add(new tModul_Map());
            modelBuilder.Configurations.Add(new tKullaniciYetki_Map());
            modelBuilder.Configurations.Add(new tTezgahPersonelEslestirme_Map());
            modelBuilder.Configurations.Add(new tPersonelTezgahHareket_Map());
            modelBuilder.Configurations.Add(new tGirdiKaliteKontrol_Map());
            modelBuilder.Configurations.Add(new tKaliteKontrolHareket_Map());
            modelBuilder.Configurations.Add(new tProsesKaliteKontrol_Map());
            modelBuilder.Configurations.Add(new tKurguProsesKaliteKontrol_Map());
            modelBuilder.Configurations.Add(new tTuketilenBilesenListesi_Map());
            modelBuilder.Configurations.Add(new tSure_Map());
            modelBuilder.Configurations.Add(new tUygunsuzUrun_Map());
            modelBuilder.Configurations.Add(new tUygunsuzUrunResimler_Map());






            // İlişkiler


            //modelBuilder.Entity<_Brk_Prj_tOrnekModel3>()
            //    .HasRequired(x => x.tOrnekModel2)
            //    .WithMany(x => x.tOrnekModel3)
            //    .HasForeignKey(x => x.OrnekModel2Id);

            //modelBuilder.Entity<_Brk_Prj_tOrnekModel3>()
            //    .HasRequired(x => x.tOrnekModel1)
            //    .WithMany(x => x.tOrnekModel3)
            //    .HasForeignKey(x => x.OrnekModel1Id);



            //modelBuilder.Entity<tLog>().ToTable("istediginizBirTabloAdi"); //toblaya istediğimiz başka bir isim atayabilmek için (varsayılan sınıf adı)

            // Özellikler eğer ilgili model üzerinde Annotations verilmez ise buradan tanımlanır.




            Database.SetInitializer<EFContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
