
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var ret = entities.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var entry = context.Entry<T>(entity);
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

        public List<T> GetItems(Expression<Func<T, bool>> predicate, params string[] navigationProperties)
        {
            List<T> list;
          
            var query = context.Set<T>().AsQueryable();

            foreach (string navigationProperty in navigationProperties)
                query = query.Include(navigationProperty);

            if(predicate != null)
                list = query.Where(predicate).ToList<T>();
            else
                list = query.ToList<T>();
            
            return list;
        }

        public void Commit()
        {
            //context.SaveChanges();
        }
    }
}