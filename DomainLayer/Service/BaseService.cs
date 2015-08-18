using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace DomainLayer.Service
{
    public abstract class BaseService<TModel> where TModel : BaseEntity
    {
        private DbContext DbContext;
        protected DbSet<TModel> DbSet => DbContext.Set<TModel>();


        protected BaseService(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public virtual void Create( TModel model )
        {
            DbSet.Add(model);
        }

        public virtual TModel Retrieve(int id)
        {
            return DbSet.FirstOrDefault(c => c.Id == id && c.IsDeleted == false);
        }

        public virtual void Update(TModel model)
        {
            DbContext.Entry(model).State=EntityState.Modified;
        }

        public virtual void Delete(TModel model)
        {
            DbContext.Entry(model).State=EntityState.Deleted;
        }
        public List<TResult> GetAll<TResult>(Expression<Func<TModel, bool>> predicate, Expression<Func<TModel, TResult>> selector , bool isTracking=true) where TResult : class
        {
            return isTracking? DbSet.Where(c=>c.IsDeleted==false).Where(predicate).Select(selector).ToList(): DbSet.Where(c => c.IsDeleted == false).Where(predicate).Select(selector).AsNoTracking().ToList();
        }

        public List<TResult> GetAll<TResult>(Expression<Func<TModel, TResult>> selector,bool isTracking = true) where TResult:class 
        {
            return isTracking ? DbSet.Where(c => c.IsDeleted == false).Select(selector).ToList() : DbSet.Where(c => c.IsDeleted == false).Select(selector).AsNoTracking().ToList();
        } 
    }
}
