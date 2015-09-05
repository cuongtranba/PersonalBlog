using System.Data.Entity.ModelConfiguration;
using DAL.Entities;

namespace Web.Models.Map
{
    public class ImageConfiguration: EntityTypeConfiguration<Image>
    {
        public ImageConfiguration()
        {
            this.Map(c => c.MapInheritedProperties());
            this.Property(c=>c.Name).HasMaxLength(50);
            this.HasMany(c => c.Posts).WithMany(c => c.Images).Map(c => c.ToTable("PostImage"));
        }
    }
}
