using System;
using System.Collections.Generic;
using DAL.Entities;

namespace Web.Models
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
        public string Meta { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryModel Category { get; set; }
        public virtual ICollection<TagModel> Tags { get; set; }
        public virtual ICollection<ImageModel> Images { get; set; }

        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
        public virtual ICollection<CommentModel> Comments { get; set; }

    }
}
