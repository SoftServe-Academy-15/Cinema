using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public TEntity? GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            TEntity? entity = dbSet.Find(id);
            if (entity != null) Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}


