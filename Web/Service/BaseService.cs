using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using Web.Models.Entity;

namespace Web.Service
{
    public abstract class BaseService<TModel> where TModel : BaseEntity
    {
        private readonly DbContext _dbContext;
        protected DbSet<TModel> DbSet => _dbContext.Set<TModel>();

        private IQueryable<TModel> DbSetQuery()
        {
            return DbSet.AsNoTracking().Where(c=>c.IsDeleted==false);
        }

        protected BaseService(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public virtual void Create( TModel model )
        {
            DbSet.Add(model);
        }

        public virtual TModel Retrieve(int id)
        {
            return DbSetQuery().FirstOrDefault(c => c.Id == id && c.IsDeleted == false);
        }

        public virtual void Update(TModel model)
        {
            DbSet.Attach(model);
            _dbContext.Entry(model).State=EntityState.Modified;
        }

        public virtual void Delete(TModel model)
        {
            _dbContext.Entry(model).State=EntityState.Deleted;
        }
        public List<TResult> GetAll<TResult>(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, TResult>> selector ) where TResult : class
        {
            return DbSetQuery().Where(predicate).Select(selector).ToList();
        }

        public List<TResult> GetAll<TResult>(Expression<Func<TModel, TResult>> selector) where TResult:class
        {
            return DbSetQuery().Select(selector).ToList();
        }

        

    }
}
