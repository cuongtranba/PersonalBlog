using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Image:BaseEntity
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public List<Post> Posts { get; set; }
    }
}
