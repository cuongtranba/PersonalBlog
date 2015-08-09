using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Config
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
