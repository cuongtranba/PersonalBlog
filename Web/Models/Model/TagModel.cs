using System.Collections.Generic;

namespace Web.Models.Model
{
    public class TagModel:BaseModel
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
