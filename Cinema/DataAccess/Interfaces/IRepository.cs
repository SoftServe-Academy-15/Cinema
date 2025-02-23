﻿using Ardalis.Specification;

namespace DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);

        IEnumerable<TEntity> GetListBySpec(ISpecification<TEntity> specification);
        TEntity? GetFirstBySpec(ISpecification<TEntity> specification);

        void Save();
    }
}
