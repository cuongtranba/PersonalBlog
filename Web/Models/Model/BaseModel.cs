using System;

namespace Web.Models.Model
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public string UrlSlug { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateTime { get; set; }

        protected BaseModel()
        {
            DateTime=DateTime.Now;
        }
    }
}
