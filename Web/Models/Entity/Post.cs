using System;
using System.Collections.Generic;
using DAL.Entities;
using Web.Models.Model;

namespace Web.Models.Entity
{
    public class Post:BaseEntity
    {
        public Post()
        {
            Tags=new List<Tag>();
            Images=new List<Image>();
            Comments=new List<Comment>();
        }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Meta { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Image> Images { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
