using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace DomainLayer.Service
{
    public abstract class BaseService<TModel, TEntities> where TEntities : IDbSet<TModel> where TModel : class
    {
        protected TEntities Entities { get; set; }
        protected DbContext Db { get; set; }


        protected BaseService(DbContext db, TEntities entities)
        {
            Db = db;
            Entities = entities;
        }

        public virtual TModel Create()
        {
            return Entities.Create();
        }

        public virtual TModel Retrieve(params object[] keys)
        {
            return Entities.Find(keys);
        }

        public virtual void Update(TModel existing)
        {
            Db.Entry(existing).State = EntityState.Modified;
        }

        public virtual void Delete(TModel existing)
        {
            Db.Entry(existing).State = EntityState.Deleted;
        }

    }
}
