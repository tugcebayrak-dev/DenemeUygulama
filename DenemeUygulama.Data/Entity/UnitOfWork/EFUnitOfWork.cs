using DenemeUygulama.Data.Araclar;
using DenemeUygulama.Data.Entity.Models;
using DenemeUygulama.Data.Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using static DenemeUygulama.Data.Araclar.Enums;

namespace DenemeUygulama.Data.Entity.UnitOfWork
{
    public class UnitOfWork : IEFUnitOfWork
    {
        private readonly Context.EFContext _dbContext;

        public UnitOfWork(Context.EFContext dbContext)
        {
            Database.SetInitializer<DbContext>(null);

            if (dbContext == null)
                throw new ArgumentNullException("dbContext boş olamaz.");

            _dbContext = dbContext;

            //_dbContext.Configuration.LazyLoadingEnabled = false;
            //_dbContext.Configuration.ValidateOnSaveEnabled = false;
            //_dbContext.Configuration.ProxyCreationEnabled = false;
        }

        #region IUnitOfWork Members
        public IEFRepository<T> GetRepository<T>() where T : BaseClass
        {
            return new EFRepository<T>(_dbContext);
        }

        public int DegisiklikleriKaydet(int kullaniciId)
        {
            try
            {
                var degisiklikler = _dbContext.ChangeTracker.Entries();
                var eklemeLoglari = new List<Tuple<tLog, object>>();
                foreach (var dbEntityEntry in degisiklikler)
                {
                    if (dbEntityEntry.Entity is tLog) // Log tablosu için log tutulmaz
                        continue;
                    if (dbEntityEntry.Entity is tHataLog) // Log tablosu için log tutulmaz
                        continue;

                    switch (dbEntityEntry.State)
                    {
                        case EntityState.Added:
                            {
                                var tumDegerler = dbEntityEntry.CurrentValues;

                                var degerler = "";
                                var tabloAdi = ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType()).Name;

                                foreach (var kolonAdi in tumDegerler.PropertyNames)
                                {
                                    var orgDeger = tumDegerler[kolonAdi];
                                    var deger = orgDeger == null ? "" : orgDeger.ToString();
                                    //Log.Instance.Yaz(tabloAdi + " | " + kolonAdi + " : " + deger);

                                    degerler += "~" + deger;
                                }

                                var logRepository = GetRepository<tLog>();

                                tLog log = new tLog();
                                log.KaynakId = tumDegerler.PropertyNames.Any(x => x == "Id") ? Convert.ToInt32(tumDegerler["Id"]) : 0; // Eğer Id alanı yoksa burası 0 gelecek.
                                log.KullaniciId = kullaniciId;
                                log.LogTuru = LogTuru.Eklendi;
                                log.TabloAdi = tabloAdi;
                                log.Kolonlar = string.Join("~", tumDegerler.PropertyNames);
                                log.Degerler = degerler.Trim('~');
                                log.Tarih = DateTime.Now;
                                logRepository.Ekle(log);

                                eklemeLoglari.Add(new Tuple<tLog, object>(log, dbEntityEntry.Entity));
                            }
                            break;
                        case EntityState.Modified:
                            {
                                var oncekiDegerler = dbEntityEntry.GetDatabaseValues();
                                var tumDegerler = dbEntityEntry.CurrentValues;

                                var logTuru = LogTuru.Guncellendi;

                                if (oncekiDegerler.PropertyNames.Any(x => x == "Silindi") && !(bool)oncekiDegerler["Silindi"] && (bool)tumDegerler["Silindi"]) // Silindi olarak işaretlendi.
                                    logTuru = LogTuru.Silindi;

                                var degerler = "";
                                var tabloAdi = ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType()).Name;

                                foreach (var kolonAdi in oncekiDegerler.PropertyNames)
                                {
                                    var orgDeger = oncekiDegerler[kolonAdi];
                                    var deger = orgDeger == null ? "" : orgDeger.ToString();
                                    //Log.Instance.Yaz(tabloAdi + " | " + kolonAdi + " : " + deger);

                                    degerler += "~" + deger;
                                }

                                var logRepository = GetRepository<tLog>();

                                tLog log = new tLog();
                                log.KaynakId = oncekiDegerler.PropertyNames.Any(x => x == "Id") ? Convert.ToInt32(oncekiDegerler["Id"]) : 0; // Eğer Id alanı yoksa burası 0 gelecek.
                                log.KullaniciId = kullaniciId;
                                log.LogTuru = logTuru;
                                log.TabloAdi = tabloAdi;
                                log.Kolonlar = string.Join("~", oncekiDegerler.PropertyNames);
                                log.Degerler = degerler.Trim('~');
                                log.Tarih = DateTime.Now;
                                logRepository.Ekle(log);
                            }
                            break;
                        case EntityState.Deleted:
                            {
                                var oncekiDegerler = dbEntityEntry.OriginalValues;

                                var degerler = "";
                                var tabloAdi = ObjectContext.GetObjectType(dbEntityEntry.Entity.GetType()).Name;

                                foreach (var kolonAdi in oncekiDegerler.PropertyNames)
                                {
                                    var orgDeger = oncekiDegerler[kolonAdi];
                                    var deger = orgDeger == null ? "" : orgDeger.ToString();
                                    //Log.Instance.Yaz(tabloAdi + " | " + kolonAdi + " : " + deger);

                                    degerler += "~" + deger;
                                }

                                var logRepository = GetRepository<tLog>();

                                tLog log = new tLog();
                                log.KaynakId = oncekiDegerler.PropertyNames.Any(x => x == "Id") ? Convert.ToInt32(oncekiDegerler["Id"]) : 0; // Eğer Id alanı yoksa burası 0 gelecek.
                                log.KullaniciId = kullaniciId;
                                log.LogTuru = LogTuru.Silindi;
                                log.TabloAdi = tabloAdi;
                                log.Kolonlar = string.Join("~", oncekiDegerler.PropertyNames);
                                log.Degerler = degerler.Trim('~');
                                log.Tarih = DateTime.Now;
                                logRepository.Ekle(log);
                            }
                            break;
                    }

                }

                //_dbContext.Database.Log = s => Log.Instance.Yaz(s); //işlemin database de oluşan query logunu log dosyasına yazmak istenirse...

                var sonuc = _dbContext.SaveChanges();

                // Bu kısım ekleme kayıtlarının Id değerini günceller.
                foreach (var log in eklemeLoglari)
                {
                    var logRepository = GetRepository<tLog>();

                    var prop = log.Item2.GetType().GetProperty("Id");
                    if (prop != null)
                    {
                        // kaynak id güncelleniyor
                        log.Item1.KaynakId = (int)prop.GetValue(log.Item2);

                        // Degerler kolonundaki Id ksımı güncelleniyor.
                        var splitValues = log.Item1.Degerler.Split('~');
                        splitValues[0] = log.Item1.KaynakId.ToString();
                        log.Item1.Degerler = string.Join("~", splitValues);

                        logRepository.Guncelle(log.Item1);
                        DegisiklikleriKaydet(kullaniciId);
                    }
                }

                return sonuc;
            }
            catch (Exception ex)
            {
                Log.Instance.Yaz(ex.Message + ex.MetodAdi());
                throw;
            }
        }

        #endregion

        #region IDisposable Members
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
