using System.Collections.Generic;

namespace Web.Models
{
    public class TagModel:BaseModel<int>
    {
        public TagModel()
        {
            Posts=new List<PostModel>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<PostModel> Posts { get; set; }
    }
}
