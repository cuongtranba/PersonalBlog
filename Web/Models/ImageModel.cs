using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Entities;

namespace Web.Models
{
    public class ImageModel
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public virtual ICollection<PostModel> Posts { get; set; }

        public ImageModel()
        {
            Posts = new List<PostModel>();
        }
    }
}