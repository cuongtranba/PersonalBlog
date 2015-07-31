using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DomainLayer.Service
{
    public class CategoryService:BaseService<Category>,IService<Category>
    {
        public CategoryService(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
