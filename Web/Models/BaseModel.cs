using System;

namespace Web.Models
{
    public abstract class BaseModel<T>
    {
        public T Id { get; set; }
        public string UrlSlug { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateTime { get; set; }

        protected BaseModel()
        {
            DateTime=DateTime.Now;
        }
    }
}
