using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Config
{
    class CategoryConfiguration: EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            this.Map(c => c.MapInheritedProperties());
            this.Property(c => c.Name).HasMaxLength(50);
            this.Property(c => c.Description).HasMaxLength(50);
            this.HasMany(c => c.Posts).WithRequired(c => c.Category).HasForeignKey(c => c.CategoryId);
        }
    }
}
