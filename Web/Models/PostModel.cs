using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class PostModel:BaseModel<int>
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

        public CategoryModel Category { get; set; }
        public IList<TagModel> Tags { get; set; }
        public UserModel User { get; set; }
        
    }
}
