using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Config
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            this.HasKey(c => c.Id);
            this.Map(c => c.MapInheritedProperties());
            this.Property(c=>c.Title).HasMaxLength(50);
            this.Property(c=>c.ShortDescription).HasMaxLength(150);
            this.Property(c=>c.Description);
            this.Property(c=>c.Meta).HasMaxLength(50);
            this.Property(c=>c.Published);
            this.Property(c=>c.PostedOn);
            this.Property(c => c.Modified);
            this.HasMany(c => c.Tags).WithMany(c => c.Posts).Map(c =>
            {
                c.ToTable("TagPost");
            });
        }
    }
}
