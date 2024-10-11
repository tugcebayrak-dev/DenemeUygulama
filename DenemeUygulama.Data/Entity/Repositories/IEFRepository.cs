using DenemeUygulama.Data.Entity.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DenemeUygulama.Data.Entity.Repositories
{
    public interface IEFRepository<T> where T : BaseClass
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllActive();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllActive(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);
        void Ekle(T entity);
        void Guncelle(T entity);
        void Sil(T entity);
        void Sil(int id);
        void DeleteForce(T entity);
        void DeleteForce(int id);


    }
}
