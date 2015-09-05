using System;
using System.Collections.Generic;

namespace Web.Models.Model
{
    public class PostModel:BaseModel
    {
        public PostModel()
        {
            Tags=new List<TagModel>();
        }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryModel Category { get; set; }
        public virtual ICollection<TagModel> Tags { get; set; }
        public virtual ICollection<ImageModel> Images { get; set; }

        public virtual UserModel User { get; set; }
        public virtual ICollection<CommentModel> Comments { get; set; }
        public string FullName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
