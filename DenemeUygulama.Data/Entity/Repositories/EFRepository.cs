using DenemeUygulama.Data.Entity.Models;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using static DenemeUygulama.Data.Araclar.Enums;
using DenemeUygulama.Data.Araclar;

namespace DenemeUygulama.Data.Entity.Repositories
{
    public class EFRepository<T> : IEFRepository<T> where T : BaseClass
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EFRepository(Context.EFContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext boş olamaz.");

            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        #region IRepository Metodlari

        public IQueryable<T> GetAllActive()
        {
            return _dbSet.Where(t => !t.Silindi);
        }
        public IQueryable<T> GetAllActive(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(t => !t.Silindi).Where(predicate);
        }
        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(t => !t.Silindi).Where(predicate).FirstOrDefault();
        }
       public IQueryable<T> GetAll()
        {
           return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        //public IQueryable<T> GetAll(string predicate, params object[] values)
        //{
        //    return _dbSet.Where(x => !x.Silindi).Where(predicate, values);
        //}
        //public IQueryable<T> GetAllSirket(Expression<Func<T, bool>> filter = null)
        //{
        //    return filter == null ? _dbSet.Where(x => x.KayitDurumu == KayitDurumu.Aktif && x.NetsisSirketAdi == Sabitler.txtNetsisSirketAdi && x.IsletmeKodu == Sabitler.txtIsletmeKodu && x.SubeKodu == Sabitler.txtSubeKodu) : _dbSet.Where(x => x.KayitDurumu == KayitDurumu.Aktif && x.NetsisSirketAdi == Sabitler.txtNetsisSirketAdi && x.IsletmeKodu == Sabitler.txtIsletmeKodu && x.SubeKodu == Sabitler.txtSubeKodu).Where(filter);
        //}
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public void Ekle(T entity)
        {
            _dbSet.Add(entity);
            //_dbContext.SaveChanges();
        }

        public void Guncelle(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Sil(T entity)
        {
            if (entity.GetType().GetProperty("Silindi") != null)
            {
                T _entity = entity;

                _entity.GetType().GetProperty("Silindi").SetValue(_entity, true);

                Guncelle(_entity);
            }
            else
            {
                DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    _dbSet.Attach(entity);
                    _dbSet.Remove(entity);
                }
            }
        }

        public void Sil(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            else
            {
                if (entity.GetType().GetProperty("Silindi") != null)
                {
                    T _entity = entity;
                    _entity.GetType().GetProperty("Silindi").SetValue(_entity, true);

                    Guncelle(_entity);
                }
                else
                {
                    Sil(entity);
                }
            }
        }
        public void DeleteForce(T entity)
        {
            DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }

        public void DeleteForce(int id)
        {
            T entity = GetById(id);
            if (entity == null) return;
            else
            {
                DeleteForce(entity);
            }
        }
        #endregion


        #region Log Ekleme Metotları
        public void LogEkle(T entity, LogTuru logTuru, int createUserId)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new JsonCustomResolver(),
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                };

                var log = new IslemLog();
                log.KaynakTabloId = entity.GetType().GetProperty("Id").GetValue(entity).ToInt32();
                log.KullaniciId = createUserId;
                log.LogTuru = logTuru;
                log.TabloAdi = ObjectContext.GetObjectType(entity.GetType()).Name;
                log.JsonDeger = JsonConvert.SerializeObject(entity, settings);
                log.KayitTarihi = DateTime.Now;
                log.SonGuncellenmeTarihi = DateTime.Now;

                var addedEntity = _dbContext.Entry(log);
                addedEntity.State = EntityState.Added;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                //Log.Instance.Yaz(ex.Message + ex.MetodAdi());
            }
        }
        public void LogEkle_Sanal(T entity, LogTuru logTuru, int createUserId)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new JsonCustomResolver(),
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                };

                var log = new IslemLog();
                log.KaynakTabloId = entity.GetType().GetProperty("Id").GetValue(entity).ToInt32();
                log.KullaniciId = createUserId;
                log.LogTuru = logTuru;
                log.TabloAdi = ObjectContext.GetObjectType(entity.GetType()).Name;
                log.JsonDeger = JsonConvert.SerializeObject(entity, settings);
                log.KayitTarihi = DateTime.Now;
                log.SonGuncellenmeTarihi = DateTime.Now;
                _dbContext.Set<IslemLog>().Add(log);
            }
            catch (Exception)
            {
                //Log.Instance.Yaz(ex.Message + ex.MetodAdi());
            }
        }
        #endregion
        #region Parametrik olarak Log'a da kayıt atan methodlar 
        public T Ekle(T entity, bool logYapilsinMi, int userId)
        {
            entity.KayitTarihi = entity.SonGuncellenmeTarihi = DateTime.Now;
            var addedEntity = _dbContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            if (logYapilsinMi) LogEkle_Sanal(addedEntity.Entity, LogTuru.Eklendi, userId);
            _dbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public T Guncelle(T entity, bool logYapilsinMi, int userId)
        {
            entity.SonGuncellenmeTarihi = DateTime.Now;
            var updatedEntity = _dbContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            if (logYapilsinMi) LogEkle_Sanal(updatedEntity.Entity, LogTuru.Guncellendi, userId);
            _dbContext.SaveChanges();
            return updatedEntity.Entity;
        }

        public void Gercek_Sil(T entity, bool logYapilsinMi, int userId)
        {
            var deletedEntity = _dbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            if (logYapilsinMi) LogEkle_Sanal(deletedEntity.Entity, LogTuru.Silindi, userId);
            _dbContext.SaveChanges();
        }

        public bool Sil_Durum(int id, bool logYapilsinMi, int userId)
        {
            var deletedEntity = _dbSet.Find(id);
            if (deletedEntity != null)
            {
                deletedEntity.KayitDurumu = KayitDurumu.Silindi;
                deletedEntity.SonGuncellenmeTarihi = DateTime.Now;
                if (logYapilsinMi) LogEkle_Sanal(deletedEntity, LogTuru.Silindi, userId);
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
        #endregion
        #region SaveChanges metoduna gereksinim duyan methodlar. (Sanal Ekleme)
        public T Ekle_Sanal(T entity)
        {
            entity.SonGuncellenmeTarihi = entity.KayitTarihi = DateTime.Now;
            return _dbSet.Add(entity);
        }

        public void Guncelle_Sanal(T entity)
        {
            entity.SonGuncellenmeTarihi = DateTime.Now;
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Sil_Gercek_Sanal(T entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }
        public bool Sil_Durum_Sanal(int id, bool logYapilsinMi, int userId)
        {
            var deletedEntity = _dbSet.Find(id);
            if (deletedEntity != null)
            {
                deletedEntity.KayitDurumu = KayitDurumu.Silindi;
                deletedEntity.SonGuncellenmeTarihi = DateTime.Now;
                if (logYapilsinMi) LogEkle_Sanal(deletedEntity, LogTuru.Silindi, userId);
                return true;
            }
            else
                return false;
        }

        #endregion

    }
}
