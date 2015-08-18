using System.Collections.Generic;

namespace DAL.Entities
{
    public class Comment:BaseEntity
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
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
