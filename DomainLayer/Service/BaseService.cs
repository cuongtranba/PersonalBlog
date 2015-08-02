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
    public abstract class BaseService<TModel> where TModel : class
    {
        protected DbContext DbContext;
        protected DbSet<TModel> DbSet => DbContext.Set<TModel>();


        protected BaseService(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public virtual TModel Create()
        {
            return DbSet.Create();
        }

        public virtual void Create( TModel model )
        {
            DbSet.Add(model);
        }

        public virtual TModel Retrieve(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public virtual void Update(TModel model)
        {
            DbContext.Entry(model).State=EntityState.Modified;
        }

        public virtual void Delete(TModel model)
        {
            DbContext.Entry(model).State=EntityState.Deleted;
        }

        public List<TModel> GetAll(Expression<Func<TModel, bool>> predicate,bool isTracking=true)
        {
            return isTracking? DbSet.Where(predicate).ToList(): DbSet.Where(predicate).AsNoTracking().ToList();
        }


    }
}
