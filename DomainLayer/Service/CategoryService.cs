using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public List<Post> GetPostByCategory(int id)
        {
            var category = DbSet.AsNoTracking().Include(p => p.Posts.Select(c=>c.User)).FirstOrDefault(c => c.Id == id);
            if (category != null)
                return category.Posts.ToList();
            return new List<Post>();
        }
    }
}
