using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User:BaseEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Profile { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IList<Post> Posts { get; set; }

        public User()
        {
            Posts=new List<Post>();
        }
    }
}
