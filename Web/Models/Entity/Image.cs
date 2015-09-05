using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models.Entity;

namespace DAL.Entities
{
    public class Image:BaseEntity
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public Image()
        {
            Posts=new List<Post>();
        }
    }
}
