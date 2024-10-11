using System.Linq;
using DenemeUygulama.Data.Araclar;
using DenemeUygulama.Data.Entity.Models;
using DescriptionLibrary;
using DenemeUygulama.Data.Tools;

namespace DenemeUygulama.Data.Migrations
{
    using global::Dapper;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;

    public sealed class Configuration : DbMigrationsConfiguration<DenemeUygulama.Data.Entity.Context.EFContext>
    {
        /// <summary>
        /// Manuel olan Migrationu otomatiðe almak için
        /// 1- Migration Klasörünü Sil
        /// 2- Package Manager Console da "enable-migration" kodunu çalýþtýr.
        /// 3- Aþaðýdaki Configuration blogunda "AutomaticMigrationsEnabled" ve "AutomaticMigrationDataLossAllowed" alanlarýný "true" yap.
        /// 4- Projenin ilk çalýþma kýsmýnda "var dbMigrator = new DbMigrator(new LisansData.Migrations.Configuration()); dbMigrator.Update();" kodlarýnýn çalýþmasýný saðla.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //false; 
            AutomaticMigrationDataLossAllowed = true; // bu özellik açýlýrsa tabloda yapýlan deðiþiklik veri kaybýna sebep verse bile uygulanýr.!!!
            //AutomaticMigrationDataLossAllowed = true; // bu özellik açýlýrsa tabloda yapýlan deðiþiklik veri kaybýna sebep verse bile uygulanýr.!!!

        }
        public static string appPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        protected override void Seed(Entity.Context.EFContext context)
        {
            
              IniFile myIni = new IniFile(appPath + "\\Cn.cfg");


           var netsisSirket = myIni.Read("DenemeUygulama", "NetsisSirket");

            
            var sifre = "berka";
            var _countKullanici = context.tKullanici.Count();
            if (_countKullanici == 0)
            {
                context.tKullanici.AddOrUpdate(
                    new tKullanici
                    {
                        KullaniciAdi = "berka",
                        KullaniciSifresi = Sifreleme.Encrypt(sifre),
                        KullaniciAdSoyad = "Berka Yazilim",
                        Yetki = Enums.Yetki.Admin,
                        YetkiText = "Admin",
                        Baslatabilir = true,
                        Bekletebilir = true,
                        Bitirebilir = true,
                        AktifCalisiyorMu = true,
                        KayitTarihi = DateTime.Now,
                        KayitDurumu = Enums.KayitDurumu.Aktif,

                    }
                    );
            }


            //#region Kurgu
            //var repo = context.tOperasyonKurgu;
            //var count = repo.Count();


            //if (count == 0)
            //{


            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.UAK.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.UAK,
            //    });







            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.FASON.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.FASON,
            //    });

            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.DAT.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.DAT,
            //    });

            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.ETIKET.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.ETIKET,
            //    });


            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.REZERVASYON.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.REZERVASYON,
            //    });




            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.ARAURETIM.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.ARAURETIM,
            //    });

            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.ALTERNATIFURETIM.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.ALTERNATIFURETIM,
            //    });

            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.SERILOT.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.SERILOT,
            //    });


            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.BILGILENDIRME.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.BILGILENDIRME,
            //    });

            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.PROCESSKALITEKONTROL.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.PROCESSKALITEKONTROL,
            //    });


            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.URETIMSONUKAYDI.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.URETIMSONUKAYDI,
            //    });

            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.ONAY.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.ONAY,
            //    });


            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.GIRDIKALITEKONTROL.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.GIRDIKALITEKONTROL,
            //    });



            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.OPERASYONGENELKURGUSU.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.OPERASYONGENELKURGUSU,
            //    });


            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.OPERASYONBITISETIKETI.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.OPERASYONBITISETIKETI,
            //    });


            //    context.tOperasyonKurgu.AddOrUpdate(new tOperasyonKurgu()
            //    {
            //        KurguAdi = Enums.OperasyonKurgu.OPERASYONBASLATMAETIKETI.Description(),
            //        KayitTarihi = DateTime.Now,
            //        KurguTipi = Enums.OperasyonKurgu.OPERASYONBASLATMAETIKETI,
            //    });



            //}


            //#endregion


            //#region Modüller
            //var repomodul = context.tModul;
            //var countmodul = repomodul.Count();


            //if (countmodul == 0)
            //{
            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Proje Kodlarý",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Girdi Kalite Kontrol",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });


            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Vekil Kullanýcý",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Proses Kalite Kontrol",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Kullanýcýlar",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });


            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Operasyonlar",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });


            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Istasyonlar",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });


            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Arýzalar",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Reçeteler",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Tezgah",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });


            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Planlama",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Planlanan Ýþ Emirleri",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Operasyon Kurgusu",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Operasyon Kurgu Eþleþtirme",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Ýstasyon Ýliþkilendirme",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Etiket Tasarýmý",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Kullanýcý Vekil Atama",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Üretim Sonu Kaydý",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Proses Kalite Kontrol",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Kullanýcý Yetki Tanýmlama",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Baðlantý Ayarlarý",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });

            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Parametre Ayarlarý",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });


            //    context.tModul.AddOrUpdate(new tModul()
            //    {
            //        ModulAdi = "Modül Ekleme",
            //        KayitDurumu = Enums.KayitDurumu.Aktif,

            //        KayitTarihi = DateTime.Now
            //    });



            //}
            //#endregion


            #region VÝEWLAR,PROSEDURE,FUNCTION

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DenemeUygulamaConnectionName"].ConnectionString))
            {
                if(!netsisSirket.IsNullOrEmpty())
                {
                    var sqlAriza = "IF EXISTS(SELECT * FROM  sys.views where name = 'brk_TBLARIZA' ) " +
                                   "         BEGIN " +
                                   "         SELECT 1 sonuc; " +
                                   "                         END; " +
                                   "                         ELSE " +
                                   "                         BEGIN " +
                                   "         EXEC(' " +
                                   "         CREATE VIEW[dbo].[brk_TBLARIZA] " +
                                   "         AS " +
                                   $"         SELECT ISLETME_KODU, ARIZAKODU,[{netsisSirket}].dbo.trk(ACIKLAMA) AS ACIKLAMA FROM " +netsisSirket + " .[dbo].[TBLUAKARIZASABIT] ')            " +
                                   " end; ";

                    var resultAriza = db.Execute(sqlAriza);


                    var sqlCaSabit = "IF EXISTS(SELECT * FROM  sys.views where name = 'brk_TBLCASABIT' ) " +
                                      "  BEGIN " +
                                      "  SELECT 1 sonuc; " +
                                      "  END; " +
                                      "  ELSE " +
                                      "  BEGIN " +
                                      "  EXEC(' " +
                                      "  CREATE VIEW [dbo].[brk_TBLCASABIT] " +
                                      "  AS " +
                                     " SELECT t.CARI_KOD, " +
                                       $"        {netsisSirket}.[dbo].trk(t.CARI_ISIM) AS CARI_ISIM " +
                                     $"   FROM {netsisSirket}.[dbo].[TBLCASABIT] t WITH (NOLOCK); " +
                                      "  ') " +
                                      "  end; ";
                    var resultCaSabit = db.Execute(sqlCaSabit);







                    var sqlEvrak = @"IF EXISTS(SELECT * FROM  sys.views where name = 'brk_TBLEVRAK' ) " +
                                             "   BEGIN " +
                                             "   SELECT 1 sonuc; " +
                                             "   END; " +
                                             "   ELSE " +
                                             "   BEGIN " +
                                             "   EXEC(' " +
                                             "   CREATE VIEW [dbo].[brk_TBLEVRAK] " +
                                              "  AS " +
                                              "  SELECT KOD, " +
                                              "         EVRAKTIPI, " +
                                              "         BILGI, " +
                                              $"         [{netsisSirket}].dbo.TRK(ACIKLAMA) AS ACIKLAMA, " +
                                              "         DOSYAADI " +
                                              $"  FROM [{netsisSirket}].[dbo].[TBLEVRAK]; " +
                                              "  ') " +
                                              "  end; ";
                    var resultEvrak = db.Execute(sqlEvrak);







                    var sqlIrsaliye = @"IF EXISTS(SELECT * FROM  sys.views where name = 'brk_TBLIRSALIYE' ) " +
                                          "  BEGIN " +
                                          "  SELECT 1 sonuc; " +
                                          "  END; " +
                                          "  ELSE " + 
                                           " BEGIN " +
                                           " EXEC(' " +
                                          "  CREATE VIEW [dbo].[brk_TBLIRSALIYE] " +
                                          "  AS " +
                                           " SELECT " +
                                          "  FATIRS_NO AS FATIRSNO " +
                                          "  , CARI_KODU AS CARIKODU " +

                                           "  FROM " +
                                           $" {netsisSirket}.dbo.TBLFATUIRS WITH (NOLOCK) " +
                                           " WHERE  FTIRSIP=''4'' " +
                                           " ') " +
                                           " end;  ";
                    var resultIrsaliye = db.Execute(sqlIrsaliye);










                    var sqlIsEmri = @"IF EXISTS(SELECT * FROM  sys.views where name = 'brk_TBLISEMRI' ) " +
                                          "  BEGIN " +
                                          "  SELECT 1 sonuc; " +
                                          "  END; " +
                                           " ELSE " +
                                          "  BEGIN " +
                                          "  EXEC(' " +

                                           " CREATE VIEW [dbo].[brk_TBLISEMRI] " +
                                           " AS " +
                                           " SELECT " +
                                           " ISEMRINO " +
                                           " , STOK_KODU " + 
                                           " , KAPALI " +
                                           $" FROM {netsisSirket}.dbo.TBLISEMRI " +
                                           " ') " +
                                           " end; ";
                    var resultIsEmri = db.Execute(sqlIsEmri);














                    var sqlIstasyon = @"IF EXISTS (SELECT * FROM sys.views WHERE name = 'brk_TBLISTASYON') " +
                                             "   BEGIN " +
                                             "       SELECT 1 sonuc; " +
                                             "   END; " +
                                             "   ELSE " +
                                             "   BEGIN " +
                                             "       EXEC (' " +

                                             "   CREATE VIEW [dbo].[brk_TBLISTASYON] " +
                                             "   AS " +
                                             "   SELECT ISTKODU, " +
                                             $"          [{netsisSirket}].dbo.TRK(ISTISIM) AS ISTISIM " +
                                             $"   FROM [{netsisSirket}].[dbo].[TBLISTASYON]; " +
                                             "   '        ); " +
                                             "   END; ";
                    var resultIstasyon = db.Execute(sqlIstasyon);









                    var sqlkaiitekontrol = @"IF EXISTS (SELECT * FROM sys.views WHERE name = 'brk_TBLKALITEKONTROL') " +
                                           " BEGIN " +
                                           "     SELECT 1 sonuc; " +
                                           " END; " +
                                           " ELSE " +
                                           " BEGIN " +
                                           "     EXEC (' " +

                                           " CREATE VIEW [dbo].[brk_TBLKALITEKONTROL] " +
                                           " AS " +
                                           " SELECT  " +
                                           " DISTINCT " +
                                           " s.STOKKODU AS StokKodu " + 
                                           " , s.GRUPKODU AS GrupKodu " +
                                           $" , {netsisSirket}.dbo.trk(g.OLCUKODU) AS OlcumKodu " +
                                           $" , {netsisSirket}.dbo.trk(OLCUBR) AS OlcumAdi " +
                                           $" , {netsisSirket}.dbo.trk(o.ACIKLAMA) AS OlcumAciklama " +
                                           $" , s.DEPKODU AS DepartmanKodu " +



                                          $"  FROM {netsisSirket}.dbo.TBLKKCARISTOK s " +
                                          $"  LEFT JOIN {netsisSirket}.dbo.TBLKKOLCUMGRP g ON s.GRUPKODU=g.KOD " +
                                          $"   JOIN {netsisSirket}.dbo.TBLKKOLCUM o ON g.OLCUKODU=o.KOD " +
                                          "   WHERE s.STOKKODU IS NOT NULL AND g.AKTIF=''E'' AND s.AKTIF=''E'' " +


                                          "  '        ); " +
                                          "  END; ";
                    var resultkaiitekontrol = db.Execute(sqlkaiitekontrol);







                    var sqlkkmanuel = @"IF EXISTS (SELECT * FROM sys.views WHERE name = 'brk_TBLKALITEKONTROL_MANUEL') " +
                                   " BEGIN " +
                                   "     SELECT 1 sonuc; " +
                                   " END; " +
                                   " ELSE " +
                                   " BEGIN " +
                                   "     EXEC (' " +

                                   " CREATE VIEW [dbo].[brk_TBLKALITEKONTROL_MANUEL] " +
                                   " AS " +

                                   " SELECT DISTINCT " +
                                   "        g.KOD AS GrupKodu, " +
                                   $"        {netsisSirket}.dbo.trk(g.OLCUKODU) AS OlcumKodu, " +
                                  $"        {netsisSirket}.dbo.trk(o.OLCUBR) AS OlcumAdi, " +
                                   $"        {netsisSirket}.dbo.trk(o.ACIKLAMA) AS OlcumAciklama " +


                                   $" FROM {netsisSirket}.dbo.TBLKKOLCUMGRP g " +
                                  $"     JOIN {netsisSirket}.dbo.TBLKKOLCUM o " +
                                   "         ON g.OLCUKODU = o.KOD " +


                                   " '        ); " +
                                   " END; ";
                    var resultkkmanuel = db.Execute(sqlkkmanuel);




                    var sqlkkdep = @"IF EXISTS (SELECT * FROM sys.views WHERE name = 'brk_TBLKKDEP') " +
                                  "  BEGIN " +
                                  "      SELECT 1 sonuc; " +
                                  "  END; " +
                                  "  ELSE " +
                                  "  BEGIN " +
                                  "      EXEC (' " +

                                  "  CREATE VIEW [dbo].[brk_TBLKKDEP] " +
                                  "  AS " +
                                  "  SELECT DISTINCT KOD AS Kod, " +
                                $"         {netsisSirket}.dbo.TRK(ACIKLAMA) AS Aciklama " +
                                $"  FROM {netsisSirket}..TBLKKDEP; " +


                                  "  '        ); " +
                                  "  END; ";
                    var resultkkdep = db.Execute(sqlkkdep);



                    var sqlkkgrp = @"IF EXISTS (SELECT * FROM sys.views WHERE name = 'brk_TBLKKGRP') " +
                                  "  BEGIN " +
                                  "      SELECT 1 sonuc; " +
                                  "  END; " +
                                  "  ELSE " +
                                  "  BEGIN " +
                                  "      EXEC (' " +

                                  "  CREATE VIEW [dbo].[brk_TBLKKGRP] " +
                                  "  AS " +
                                  "  SELECT DISTINCT " +
                                  "         KOD AS Kod, " +
                               $"         {netsisSirket}.dbo.trk(ACIKLAMA) AS Aciklama " +
                               $"  FROM {netsisSirket}..TBLKKGRP; " +


                                  "  '        ); " +
                                  "  END;";
                    var resultkkgrp = db.Execute(sqlkkgrp);





                    var sqlkkmas = @"IF EXISTS (SELECT * FROM sys.views WHERE name = 'brk_TBLKKMAS') " +
                                   " BEGIN " +
                                   "     SELECT 1 sonuc; " +
                                   " END; " +
                                   " ELSE " +
                                  "  BEGIN " + 
                                    "    EXEC (' " +

                                   " CREATE VIEW [dbo].[brk_TBLKKMAS] " +
                                   " AS " +
                                   " SELECT IRSALIYENO, " +
                                   "        STOKKODU " +


                                        $" FROM {netsisSirket}.[dbo].[TBLKKMAS] t WITH (NOLOCK) " +



                                   " '        ); " +
                                   " END;"; 
                    var resultkkmas = db.Execute(sqlkkmas);



                    var sqlmrpmakine = @"IF EXISTS (SELECT * FROM sys.views WHERE name = 'brk_TBLMRPMAKINE') " +
                                 "   BEGIN " +
                                 "       SELECT 1 sonuc; " +
                                 "   END; " +
                                 "   ELSE " +
                                 "   BEGIN  " +
                                 "       EXEC (' " +
"                                    CREATE VIEW [dbo].[brk_TBLMRPMAKINE]  " +
                                "    AS " +
                                "    SELECT  " +
                               $"    {netsisSirket}.dbo.TRK(DEMIR_KODU) AS TezgahKodu, " +
                               $"    {netsisSirket}.dbo.TRK(DEMIR_ISMI) AS TezgahAdi, " +
                               $"    ISTKODU AS IstasyonKodu " +
                               $"   FROM {netsisSirket}.dbo.TBLMRPMAKINE; " +


                                 "   '        ); " +
                                 "   END; ";
                    var resultmrpmakine = db.Execute(sqlmrpmakine);


                    var sqltbloperasyon = @"IF EXISTS (SELECT * FROM sys.views WHERE name = 'brk_TBLOPERASYON') " +
                                       " BEGIN " +
                                       "     SELECT 1 sonuc; " +
                                       " END; " +
                                       " ELSE " +
                                       " BEGIN " +
                                       "     EXEC (' " +

"                                        CREATE VIEW [dbo].[brk_TBLOPERASYON] " +
                                      "  AS " +
                                      "  SELECT k.[ISLETME_KODU] AS IsletmeKodu " +
                                      "        , k.[OPKODU] AS OperasyonKodu " +
                                   $"       , {netsisSirket}.dbo.TRK([OPISIM]) AS OperasyonIsim " +
                                   $"        ,{netsisSirket}.dbo.TRK(k.[ACIKLAMA]) AS OperasyonAciklama " +
                                   $"        ,ý.[ISTKODU] AS IstasyonKodu " +
                                   $"        ,{netsisSirket}.dbo.TRK(ý.[ISTISIM]) AS IstasyonIsim FROM {netsisSirket}.dbo.TBLOPERATIONS_KATALOG k JOIN {netsisSirket}.dbo.TBLISTASYON ý ON ý.ISTKODU=k.ISTKODU  " +

                                       " '        ); " +
                                     "   END; ";
                    var resulttbloperasyon = db.Execute(sqltbloperasyon);




                    var sqlpersonel = @"IF EXISTS (SELECT * FROM sys.views WHERE name = 'brk_TBLPERSONEL') " +
                                       " BEGIN " +
                                       "     SELECT 1 sonuc; " +
                                       " END; " +
                                       " ELSE " +
                                       " BEGIN " +
                                        "    EXEC (' " +

                                       " CREATE VIEW [dbo].[brk_TBLPERSONEL] " +
                                       " AS " +
                                      $" SELECT SICILNO AS SicilNo,{netsisSirket}.dbo.TRK(ISIM) AS PersonelIsim,mrp.ISTKODU AS IstasyonKodu, {netsisSirket}.dbo.TRK(ýst.ISTISIM) AS IstasyonIsim FROM {netsisSirket}.dbo.TBLMRPISCI mrp JOIN {netsisSirket}.dbo.TBLISTASYON ýst ON ýst.ISTKODU=mrp.ISTKODU " +

                                        " '        ); " +
                                        " END; ";
                    var resultpersonel = db.Execute(sqlpersonel);





                    var sqltblplanlama = @"IF EXISTS (SELECT * FROM sys.views WHERE name = 'brk_TBLPLANLAMA') " +
                                        " BEGIN " +
                                         "   SELECT 1 sonuc; " +
                                        " END; " +
                                        " ELSE " +
                                       "             BEGIN " +
                                       "                 EXEC (' " +
"                                                    CREATE VIEW [dbo].[brk_TBLPLANLAMA] " +
                                       "             AS " +
                                     $"             SELECT  I.ISEMRINO,I.REFISEMRINO,{netsisSirket}.dbo.TRK(R.MAMUL_KODU) AS MAMUL_KODU " +
                                     $"             , R.HAM_KODU,I.MIKTAR,R.OPNO,K.OPKODU " +
                                     $"             , {netsisSirket}.dbo.TRK(K.OPISIM) AS OPISIM " +
                                     $"             , {netsisSirket}.dbo.TRK(R.ACIKLAMA) AS ACIKLAMA " +
                                     $"             , R.ISTKODU,{netsisSirket}.dbo.TRK(IST.ISTISIM)AS ISTISIM " + 
                                     $"             , {netsisSirket}.dbo.trk(I.STOK_KODU) AS STOK_KODU,{netsisSirket}.dbo.TRK(S.STOK_ADI) AS STOK_ADI " +
                                     $"             , I.DEPO_KODU AS DepoKodu,I.SIPARIS_NO AS SIPARIS_NO ,ca.CARI_KOD,{netsisSirket}.dbo.trk(ca.CARI_ISIM) AS CARI_ISIM " +
                                     $"             , CAST(IST.SETUPSURE AS INT) AS TahminiSure ,I.TESLIM_TARIHI AS TeslimTarihi " +
                                     $"             , {netsisSirket}.dbo.TRK(I.ACIKLAMA) AS ISEMRIACIKLAMA,I.PROJE_KODU " +
                                     $"             FROM {netsisSirket}.dbo.TBLSTOKURM R " +
                                     $"             JOIN {netsisSirket}.dbo.TBLISEMRI I WITH (NOLOCK) ON I.STOK_KODU = R.MAMUL_KODU " +
                                     $"             JOIN {netsisSirket}.dbo.TBLISTASYON IST WITH (NOLOCK) ON IST.ISTKODU = R.ISTKODU " +
                                     $"             JOIN {netsisSirket}.dbo.TBLOPERATIONS_KATALOG K WITH (NOLOCK) ON K.OPKODU = R.HAM_KODU " +
                                     $"             LEFT JOIN {netsisSirket}.DBO.tblsipatra tr WITH (NOLOCK) ON tr.FISNO=I.SIPARIS_NO AND tr.STRA_SIPKONT=I.SIPKONT " +
                                     $"             LEFT JOIN {netsisSirket}.DBO.TBLCASABIT ca WITH (NOLOCK) ON ca.CARI_KOD=tr.STHAR_ACIKLAMA " + 
                                     $"             JOIN {netsisSirket}.dbo.TBLSTSABIT S WITH (NOLOCK) ON S.STOK_KODU = R.MAMUL_KODU WHERE R.OPR_BIL=''O'' AND I.KAPALI=''H'' " +
                                     $"             '        ); " +
                                     $"             END;";
                    var resulttblplanlama = db.Execute(sqltblplanlama);



                    var sqlrecete = @"IF EXISTS (SELECT * FROM sys.views WHERE name = 'brk_TBLRECETE') " +
                                    "        BEGIN " +
                                    "            SELECT 1 sonuc; " +
                                    "        END; " +
                                    "        ELSE " +
                                    "        BEGIN " +
                                    "            EXEC (' " +

                                    "        CREATE VIEW [dbo].[brk_TBLRECETE] " +
                                    "        AS " +
                                  $"        SELECT {netsisSirket}.dbo.TRK(MAMUL_KODU) AS MAMUL_KODU, " +
                                  $"               s.OPR_BIL, " +
                                  $"               {netsisSirket}.dbo.TRK(HAM_KODU) AS HAM_KODU, " +
                                  $"               {netsisSirket}.dbo.TRK(sbt.STOK_ADI) AS STOK_ADI, " +
                                  $"               CAST(s.MIKTAR AS INT) AS MIKTAR, " +
                                  $"               {netsisSirket}.dbo.TRK(s.ACIKLAMA) AS ACIKLAMA, " +
                                  $"               {netsisSirket}.dbo.TRK(s.ISTKODU) AS ISTKODU, " +
                                  $"               {netsisSirket}.dbo.TRK(ý.ISTISIM) AS ISTISIM, " +
                                  $"               {netsisSirket}.dbo.TRK(s.OPKODU) AS OPKODU, " +
                                  $"               {netsisSirket}.dbo.TRK(o.OPISIM) AS OPISIM " +
                                  $"        FROM {netsisSirket}.dbo.TBLSTOKURM s " +
                                  $"            LEFT JOIN {netsisSirket}.dbo.TBLISTASYON ý " +
                                  $"                ON s.ISTKODU = ý.ISTKODU " +
                                  $"            LEFT JOIN {netsisSirket}.dbo.TBLOPERATIONS_KATALOG o " +
                                  $"               ON s.OPKODU = o.OPKODU " +
                                  $"         LEFT JOIN {netsisSirket}.dbo.TBLSTSABIT sbt " +
                                  $"               ON sbt.STOK_KODU = s.MAMUL_KODU; " +
                                  $"       '        ); " +
                                     "      END;";
                    var resultrecete = db.Execute(sqlrecete);



                    var sqlsthar = @"IF EXISTS (SELECT * FROM sys.views WHERE name = 'brk_TBLSTHAR') " +
                                    " BEGIN " +
                                   "     SELECT 1 sonuc; " +
                                   " END; " +
                                   " ELSE " +
                                   " BEGIN " +
                                   "     EXEC (' " +

                                  "  CREATE VIEW [dbo].[brk_TBLSTHAR] " +
                                  "  AS " +
                                  "  SELECT STOK_KODU, " +
                                  "         FISNO " +
                                  "         , STHAR_GCKOD " +
                                  "         , STHAR_GCMIK " +
                                  "         , DEPO_KODU " +
                                  "         , IRSALIYE_NO " +

                                  $"  FROM {netsisSirket}..TBLSTHAR; " +
                                  "  '        ); " +
                                  "  END;";
                    var resultsthar = db.Execute(sqlsthar);



                    var sqlstokdp = @"IF EXISTS (SELECT * FROM sys.views WHERE name = 'brk_TBLSTOKDP') " +
                                    " BEGIN " +
                                    "    SELECT 1 sonuc; " +
                                   "         END; " +
                                   "         ELSE " +
                                   "         BEGIN " +
                                   "             EXEC (' " +
                                             
                                   "         CREATE VIEW [dbo].[brk_TBLSTOKDP] " +
                                   "         AS " +
                                   $"         SELECT DEPO_KODU AS DepoKodu, {netsisSirket}.dbo.trk(DEPO_ISMI) AS DepoIsim FROM {netsisSirket}.dbo.TBLSTOKDP  " +
                                   "         '        );  " +
                                   "         END;";
                    var resultstokdp = db.Execute(sqlstokdp);




                    var sqlstsabit = @"IF EXISTS (SELECT * FROM sys.views WHERE name = 'brk_TBLSTSABIT')  " +
                                 "          BEGIN  " +
                                 "              SELECT 1 sonuc; " +
                                 "          END; " +
                                 "          ELSE  " +
                                 "          BEGIN  " +
                                 "              EXEC ('  " +
                                 
                                 "          CREATE VIEW [dbo].[brk_TBLSTSABIT]  " +
                                 "          AS  " +
                                 "          SELECT  " +
                                 $"                {netsisSirket}.[dbo].trk(t.STOK_ADI) AS STOK_ADI  " +
                                 "                , t.RISK_SURESI AS RISK_SURESI  " +
                                 "                , t.ZAMAN_BIRIMI AS ZAMAN_BIRIMI  " +
                                 "                , t.DEPO_KODU AS DEPO_KODU  " +
                                 "                , t.ALIS_KDV_KODU AS ALIS_KDV_KODU  " +
                                 "                , t.MUH_DETAYKODU AS MUH_DETAYKODU  " +
                                  
                                   
                                 "                   , t.OLCU_BR1 AS OLCU_BR1  " +
                                 "                   , t.OLCU_BR2 AS OLCU_BR2  " +
                                 "                   , t.OLCU_BR3 AS OLCU_BR3  " +
                                 "                   , t.PAY_1 AS PAY_1  " +
                                 "                   , t.PAY2 AS PAY2  " +
                                 "                   , t.PAYDA_1 AS PAYDA_1  " +
                                 "                   , t.PAYDA2 AS PAYDA2  " +
                                 "                   , t.EN AS EN  " +
                                 "                   , t.BOY AS BOY  " +
                                 "                   , t.GENISLIK AS GENISLIK  " +
                                 "                   , t.KDV_ORANI AS KDV_ORANI  " +
                                 "                   , t1.KULL1N AS KULL1N  " +
                                 "                   , t1.KULL2N AS KULL2N  " +
                                 "                   , t1.KULL3N AS KULL3N  " +
                                 "                   , t1.KULL4N AS KULL4N  " +
                                 "                   , t1.KULL5N AS KULL5N  " +
                                 "                   , t1.KULL6N AS KULL6N  " +
                                 "                   , t1.KULL7N AS KULL7N  " +
                                 "                   , t1.KULL8N AS KULL8N  " +
                               $"                   , {netsisSirket}.[dbo].trk(t1.KULL1S) AS KULL1S  " +
                               $"                   , {netsisSirket}.[dbo].trk(t1.KULL2S) AS KULL2S  " +
                               $"                   , {netsisSirket}.[dbo].trk(t1.KULL3S) AS KULL3S  " +
                               $"                   , {netsisSirket}.[dbo].trk(t1.KULL4S) AS KULL4S  " +
                               $"                   , {netsisSirket}.[dbo].trk(t1.KULL5S) AS KULL5S " +
                               $"                   , {netsisSirket}.[dbo].trk(t1.KULL6S) AS KULL6S " +
                               $"                   , {netsisSirket}.[dbo].trk(t1.KULL7S) AS KULL7S " +
                               $"                   , {netsisSirket}.[dbo].trk(t1.KULL8S) AS KULL8S " +
                                 
                                 "                   , t.BIRIM_AGIRLIK AS BIRIM_AGIRLIK " +
                                 "                   , t.NAKLIYET_TUT AS NAKLIYET_TUT " +
                                 "                   , t.ONCEKI_KOD AS ONCEKI_KOD " +
                                 "                   , t.SONRAKI_KOD AS SONRAKI_KOD " +
                                 "                   , t.BARKOD1 AS BARKOD1 " +
                                 "                   , t.BARKOD2 AS BARKOD2 " +
                                 "                   , t.BARKOD3 AS BARKOD3 " +
                                 "                   , t.SATICI_KODU AS SATICI_KODU " +
                                 "                   , t.URETICI_KODU AS URETICI_KODU " +
                                 "                   , t.SUBE_KODU AS SUBE_KODU " +
                                 "                   , t.ISLETME_KODU AS ISLETME_KODU " +
                                 "                   , t.GRUP_KODU AS GRUPKOD " +
                                 "                   , t.KOD_4 AS KOD_DORT " +
                                 "                   , t.KOD_1 AS KOD_BIR " +
                                 "                   , t.KOD_2 AS KOD_IKI " +
                                 "                   , t.KOD_3 AS KOD_UC " +
                                 "                   , t.KOD_5 AS KOD_BES " +
                                 "                   , t.ALIS_FIAT1 AS ALIS_FIAT1 " +
                                 "                   , t.ALIS_FIAT2 AS ALIS_FIAT2 " +
                                 "                   , t.ALIS_FIAT3 AS ALIS_FIAT3 " +
                                 "                   , t.ALIS_FIAT4 AS ALIS_FIAT4 " +
                                 "                   , t.SATIS_FIAT1 AS SATIS_FIAT1 " +
                                 "                   , t.SATIS_FIAT2 AS SATIS_FIAT2 " +
                                 "                   , t.SATIS_FIAT3 AS SATIS_FIAT3 " +
                                 "                   , t.SATIS_FIAT4 AS SATIS_FIAT4 " +
                                 "                   , t.ALIS_DOV_TIP AS ALIS_DOV_TIP " +
                                 "                   , t.SAT_DOV_TIP AS SAT_DOV_TIP " +
                                 "                   , t.DOV_ALIS_FIAT AS DOV_ALIS_FIAT " +
                                 "                   , t.DOV_MAL_FIAT AS DOV_MAL_FIAT " +
                                 "                   , t.DOV_TUR AS DOV_TUR " +
                                 "                   , t.FIYATKODU AS FIYATKODU " +
                                 "                   , t.FIYATSIRASI AS FIYATSIRASI " +
                                 "                   , t.GUMRUKTARIFEKODU AS GUMRUKTARIFEKODU " +
                                 "                   , t.STOK_KODU AS STOK_KODU " +
                              
                                 
                                 
                                 $"                  FROM {netsisSirket}.[dbo].[TBLSTSABIT] t WITH (NOLOCK) " +
                                 $"                 LEFT JOIN {netsisSirket}.[dbo].[TBLSTSABITEK] t1 WITH (NOLOCK) " +
                                 "                    ON t.STOK_KODU = t1.STOK_KODU " +
                                 "              '        ); " +
                                 "              END;";
                    var resultstsabit = db.Execute(sqlstsabit);





                    var sqltarihhesapla = @"IF EXISTS(SELECT * FROM Information_schema.Routines where Specific_schema = 'dbo'  AND specific_name = '_Brk_TarihHesaplama' AND Routine_Type = 'FUNCTION') " +
                           "        BEGIN " +
                           "        SELECT 1 sonuc; " +
                           "        END; " +
                           "        ELSE " +
                           "        BEGIN " +
                           "        EXEC(' " +
                           "        CREATE FUNCTION [dbo].[_Brk_TarihHesaplama](" +
                           "        @Tarih1 DATETIME, " +
                           "        @Tarih2 DATETIME) " +
                           "        RETURNS VARCHAR(MAX) " +
                           "        AS " +
                           "        BEGIN " +
                           "        DECLARE @cikis VARCHAR(10) " +
                           "        DECLARE @saniye BIGINT " +
                           "        SET @saniye=(SELECT DATEDIFF(SECOND,@Tarih1,@Tarih2)) " +
                           "        SET @saniye=ISNULL(@saniye,0) " +
                           "        SET @cikis=''0d 00:00:00'' " +
                           
                           "        IF(@saniye<0) " +
                           "        RETURN @cikis " +
                           "        SET @cikis=CONVERT(VARCHAR,FLOOR(@saniye/86400)) + ''g'' " +
                           "        SET @saniye=@saniye % 86400 " +
                           "        SET @cikis=@cikis +RIGHT(''0''+CONVERT(VARCHAR,FLOOR(@saniye/3600)),2)+ '':'' " +
                           "        SET @saniye=@saniye % 3600 " +
                           "        SET @cikis = @cikis + RIGHT(''0''+CONVERT(VARCHAR,FLOOR(@saniye /60)),2)+ '':'' " +
                           "        SET @cikis=@cikis + RIGHT(''0''+CONVERT(VARCHAR,@saniye % 60 ),2) " +
                           "        RETURN @cikis end; " + 
                           "        ') " +
                           "        end;";
                    var resulttarihhesapla = db.Execute(sqltarihhesapla);





                    var sqlnetsistenguncelle = @"IF EXISTS(SELECT * FROM Information_schema.Routines where Specific_schema = 'dbo'  AND specific_name = '_Brk_NetsistenGuncelle' AND Routine_Type = 'PROCEDURE') " +
                                   "      BEGIN " +
                                   "      SELECT 1 sonuc; " +
                                   "      END; " +
                                   "      ELSE " +
                                   "      BEGIN " +
                                   "      EXEC(' " +
                                   "      CREATE PROCEDURE [dbo].[_Brk_NetsistenGuncelle] " +
                                   "      AS " +
                                   "      BEGIN " +
                                   "          SET NOCOUNT ON; " +
                                    
                                   "          UPDATE dbo.tPlanlama " +
                                   "          SET IsEmriAciklama = " +
                                   "              ( " +
                                   "                  SELECT ISEMRIACIKLAMA " +
                                   "                  FROM dbo.brk_TBLPLANLAMA " +
                                   "                  WHERE ISEMRINO = tPlanlama.IsEmriNo " +
                                   "                        AND OPKODU = dbo.tPlanlama.OperasyonKodu " +
                                   "              ); " +
                                   "              end; " +
                                   "      ') " +
                                   "      end;";
                    var resultnetsistenguncelle = db.Execute(sqlnetsistenguncelle);

                    var sqlopbilesenleri = @"IF EXISTS(SELECT * FROM Information_schema.Routines where Specific_schema = 'dbo'  AND specific_name = '_Brk_OpBilesenleri' AND Routine_Type = 'PROCEDURE') " +
                                    "         BEGIN " +
                                    "         SELECT 1 sonuc; " +
                                    "         END; " +
                                    "         ELSE " +
                                    "         BEGIN " +
                                    "         EXEC(' " +
                                    "         CREATE PROCEDURE [dbo].[_Brk_OpBilesenleri]  " +
                                    "             @MamulKodu NVARCHAR(MAX) " +
                                    "         AS " +
                                    "         BEGIN " +
	                                "             SET NOCOUNT ON; " +
	                                "             SELECT DISTINCT  HAM_KODU AS HammaddeKodu, " +
                                    "                sbt.STOK_ADI, " +
                                    "                CAST(rec.MIKTAR AS INT) AS BilesenMiktar, " +
                                    "                UretimDepoMiktar = " +
                                    "                ( " +
                                    "                    SELECT (CAST(SUM(CASE " +
                                    "                                            WHEN har.STHAR_GCKOD = ''G'' THEN  " +
                                    "                                                har.STHAR_GCMIK " +
                                    "                                            ELSE " +
                                    "                                                - 1 * har.STHAR_GCMIK " +
                                    "                                        END " +
                                    "                                    ) AS INT) " +
                                    "                           ) " +
                                    "                    FROM dbo.brk_TBLSTHAR har " +
                                    "                    WHERE har.DEPO_KODU = 12 " +
                                    "                          AND har.STOK_KODU = rec.HAM_KODU " +
                                    "                ), " +
                                    "                AnaDepoMiktar = " +
                                    "                (" +
                                    "                    SELECT ISNULL(CAST(SUM(CASE " +
                                    "                                                  WHEN har.STHAR_GCKOD = ''G'' THEN " +
                                    "                                                      har.STHAR_GCMIK " +
                                    "                                                  ELSE " +
                                    "                                                      - 1 * har.STHAR_GCMIK " +
                                    "                                              END " +
                                    "                                          ) AS INT), " +
                                    "                                  0 " +
                                    "                                 ) " +
                                    "                    FROM dbo.brk_TBLSTHAR har " +
                                    "                    WHERE har.DEPO_KODU = 10 " +
                                    "                          AND har.STOK_KODU = rec.HAM_KODU " +
                                    "                ) " +
                                    "         FROM dbo.brk_TBLRECETE rec " +
                                    "             LEFT JOIN dbo.brk_TBLSTSABIT sbt " +
                                    "                 ON sbt.STOK_KODU = rec.HAM_KODU " +
                                    "         WHERE MAMUL_KODU = @MamulKodu " +
                                    "               AND OPR_BIL = ''B''; " +
                                    "         END " +
                                    "         ') " +
                                    "         end;";
                    var resultopbilesenleri = db.Execute(sqlopbilesenleri);





                    var sqlnetsistenguncelleisemri = @"IF EXISTS "+
                                                      "      ( " +
                                                      "          SELECT * " +
                                                      "          FROM INFORMATION_SCHEMA.ROUTINES " +
                                                      "          WHERE SPECIFIC_SCHEMA = 'dbo' " +
                                                      "                AND SPECIFIC_NAME = '_Brk_NetsistenGuncelleIsEmri' " +
                                                      "                AND ROUTINE_TYPE = 'PROCEDURE' " +
                                                      "      ) " +
                                                      "      BEGIN " +
                                                      "          SELECT 1 sonuc; " +
                                                      "      END; " +
                                                      "      ELSE " +
                                                      "      BEGIN " +
                                                      "         EXEC (' " +
                                                      "     CREATE PROCEDURE [dbo].[_Brk_NetsistenGuncelleIsEmri] " +
                                                      "      AS " +
                                                      "      BEGIN " +
                                                      "          SET NOCOUNT ON; " +
                                                      "          UPDATE  p " +
                                                      "      SET  " +
                                                      "          p.SonDurum=70, " +
                                                      "          p.SonDurumText=''Ýþ Emri Kapatýlmýþ'' " +
                                                      "     FROM " +
                                                      "            dbo.tPlanlama p " +
                                                      "          LEFT JOIN brk_TBLISEMRI isemri ON p.IsEmriNo=isemri.ISEMRINO " +
                                                      "           WHERE Silindi = 0 and isemri.KAPALI = ''E'' " +
                                                      "              END; " +
                                                      "                                           '); " +
                                                      "      END ";
                    var resultnetsistenguncelleisemri = db.Execute(sqlnetsistenguncelleisemri);

                }
               
            }

            #endregion




        }
    }
}
