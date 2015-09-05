using System.Data.Entity.ModelConfiguration;
using DAL.Entities;
using Web.Models.Entity;

namespace Web.Models.Map
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            this.Map(c => c.MapInheritedProperties());
            this.Property(c=>c.Title).HasMaxLength(50);
            this.Property(c=>c.ShortDescription).HasMaxLength(150);
            this.Property(c=>c.Description).IsMaxLength();
            this.Property(c=>c.Meta).HasMaxLength(50);
            this.Property(c=>c.Published);
            this.Property(c=>c.PostedOn);
            this.Property(c => c.Modified);
            this.HasMany(c => c.Tags).WithMany(c => c.Posts).Map(c =>
            {
                c.ToTable("TagPost");
            });
            this.HasMany(c=>c.Comments).WithRequired(c=>c.Post).HasForeignKey(c=>c.PostId).WillCascadeOnDelete(false);
        }
    }
}
