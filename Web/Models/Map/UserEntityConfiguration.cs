using System.Data.Entity.ModelConfiguration;
using Web.Models.Entity;
using Web.Models.Model;

namespace Web.Models.Map
{
    public class UserEntityConfiguration: EntityTypeConfiguration<ApplicationUser>
    {
        public UserEntityConfiguration()
        {
            this.Property(c => c.IsDeleted);
            this.HasMany(c => c.Posts).WithRequired(s => s.User).HasForeignKey(c=>c.UserId).WillCascadeOnDelete(false);
            this.HasMany(c => c.Comments).WithRequired(s => s.User).HasForeignKey(c => c.UserId).WillCascadeOnDelete(false);
        }
    }
}
