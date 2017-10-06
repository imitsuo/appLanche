
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace appLanche.Infrastructure
{
public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LancheContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
 
        public Repository(LancheContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }
 
        public T Get<TKey>(TKey id)
        {
            return entities.Find(id);
        }

        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();

            return entity;
        }
 
        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var entry  = context.Entry<T>(entity);
            entry.State = EntityState.Modified;

            context.SaveChanges();
        }
 
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public void Commit()
        {
            //context.SaveChanges();
        }
    }
}