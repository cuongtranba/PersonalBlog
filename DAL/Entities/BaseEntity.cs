using System;

namespace DAL.Entities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
        public string UrlSlug { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateTime { get; set; }
    }
}
