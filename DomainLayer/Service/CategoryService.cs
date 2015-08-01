using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DomainLayer.Service.Interface;

namespace DomainLayer.Service
{
    public class CategoryService:BaseService<Category>, ICategoryService
    {
        public CategoryService(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
