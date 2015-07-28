using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Config
{
    public class UserEntityConfiguration: EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            this.HasKey(c => c.Id);
            this.Map(c => c.MapInheritedProperties());
            this.Property(c => c.DateOfBirth).HasColumnType("datetime2").HasColumnName("DOB");
            this.Property(c => c.Profile).HasMaxLength(150);
            this.Property(c => c.Name).HasMaxLength(50);
            this.Property(c => c.Email).HasMaxLength(50);
            this.HasMany(c => c.Posts).WithRequired(s => s.User);
        }
    }
}
