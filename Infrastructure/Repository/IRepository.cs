
using System.Collections.Generic;

namespace appLanche.Infrastructure
{
public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get<TKey>(TKey id);
        T Insert(T entity);       
        void Update(T entity);
        void Delete(T entity);
        void Commit();
    }
}