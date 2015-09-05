using System.Collections.Generic;
using DAL.Entities;
using Web.Models.Entity;

namespace Web.Models.Model
{
    public class CommentModel:BaseModel
    {
        public string Content { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
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