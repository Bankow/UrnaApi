using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using UrnaEletronica.Domain.Entities.Core;
using UrnaEletronica.Domain.Repositories.Core;
using UrnaEletronica.Infrastructure.Repositories.Core;

namespace ReleaseManager.Infrastructure.Repositories.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(UrnaEletronicaContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }

        public bool Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Add(entity);

            Commit();

            return true;
        }

        public bool Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Update(entity);

            Commit();

            return true;
        }

        public bool Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbSet.Remove(entity);

            Commit();

            return true;
        }

        public IQueryable<TEntity> Query()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<TEntity> QueryAsTracking()
        {
            return _dbSet;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
    }
}