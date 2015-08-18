using System.Collections.Generic;
using DAL.Entities;

namespace Web.Models
{
    public class CommentModel:BaseModel
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public int? CommentId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public CommentModel()
        {
            Comments = new List<Comment>();
        }
    }
}