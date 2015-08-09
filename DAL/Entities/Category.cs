using System.Collections.Generic;

namespace DAL.Entities
{
    public class Category:BaseEntity
    {
        public Category()
        {
            Posts=new List<Post>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Post> Posts { get; set; }
    }
}
