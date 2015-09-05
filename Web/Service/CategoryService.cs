using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Entities;
using Web.Models.Entity;
using Web.Service.Interface;

namespace Web.Service
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
