using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Config
{
    public class TagEntityConfiguration: EntityTypeConfiguration<Tag>
    {
        public TagEntityConfiguration()
        {
            this.HasKey(c => c.Id);
            this.Map(c => c.MapInheritedProperties());
            this.Property(c => c.Name).HasMaxLength(50);
            this.Property(c => c.Description);
            this.HasMany(c => c.Posts).WithMany(c => c.Tags).Map(c =>
            {
                c.ToTable("TagPost");
            });

        }
    }
}
