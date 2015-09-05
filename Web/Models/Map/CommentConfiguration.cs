using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace Web.Models.Map
{
    public class CommentConfiguration: EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            this.Map(c=>c.MapInheritedProperties());
            this.Property(c => c.Content).HasMaxLength(300);
            this.HasMany(c => c.Comments);
        }
    }
}
