using System.Collections.Generic;
using Web.Models.Entity;
using Web.Models.Model;

namespace DAL.Entities
{
    public class Comment:BaseEntity
    {
        public string Content { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public int? CommentId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public Comment()
        {
            Comments=new List<Comment>();
        }
    }
}
