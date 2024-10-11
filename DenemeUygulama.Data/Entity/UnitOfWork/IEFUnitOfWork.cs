using DenemeUygulama.Data.Entity.Models;
using DenemeUygulama.Data.Entity.Repositories;
using System;

namespace DenemeUygulama.Data.Entity.UnitOfWork
{
    public interface IEFUnitOfWork : IDisposable
    {
        IEFRepository<T> GetRepository<T>() where T : BaseClass;
        int DegisiklikleriKaydet(int kullaniciId);
    }
}
