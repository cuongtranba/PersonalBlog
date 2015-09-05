using System.Collections.Generic;

namespace Web.Models.Model
{
    public class CategoryModel:BaseModel
    {
        public CategoryModel()
        {
            Posts=new List<PostModel>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CountPost { get; set; }
        public IList<PostModel> Posts { get; set; }
    }
}
