using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Config
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
