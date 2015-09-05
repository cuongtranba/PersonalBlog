using System.Collections.Generic;
using Web.Models.Entity;

namespace Web.Service.Interface
{
    public interface ICategoryService : IService<Category>
    {
        List<Post> GetPostByCategory(int id);
    }
}
