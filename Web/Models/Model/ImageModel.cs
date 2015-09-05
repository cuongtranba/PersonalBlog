using System.Collections.Generic;

namespace Web.Models.Model
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