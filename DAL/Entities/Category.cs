using System.Collections.Generic;

namespace DAL.Entities
{
    public class Category:BaseEntity<int>
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
