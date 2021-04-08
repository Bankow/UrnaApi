using System;
using System.Linq;
using UrnaEletronica.Domain.Entities.Core;

namespace UrnaEletronica.Domain.Repositories.Core
{
    public interface IRepository<TEntity> : IDisposable
    where TEntity : IEntity
    {
        bool Insert(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);

        IQueryable<TEntity> Query();

        IQueryable<TEntity> QueryAsTracking();

        int Commit();

    }
}
