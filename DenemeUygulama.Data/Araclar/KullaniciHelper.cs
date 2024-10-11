using DenemeUygulama.Data.Entity.Context;
using DenemeUygulama.Data.Entity.Models;
using DenemeUygulama.Data.Entity.UnitOfWork;

namespace DenemeUygulama.Data.Araclar
{
    public static class KullaniciHelper
    {
        public static tKullanici Getir(string _kullaniciAdi)
        {
            using (var _uow = new UnitOfWork(new EFContext()))
            {
                var _tKullaniciRepository = _uow.GetRepository<tKullanici>();
                return _tKullaniciRepository.Get(x => x.KullaniciAdi == _kullaniciAdi);
            }
        }

    }
}
