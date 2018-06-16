using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ysamedia.Models;

namespace ysamedia.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>().ToTable("tblUser").Property(p => p.Id).HasColumnName("UserId");
            builder.Entity<ApplicationUser>().ToTable("tblUser").Property(p => p.Id).HasColumnName("UserId");
            builder.Entity<IdentityUserRole<string>>().ToTable("tblUserRole");
            builder.Entity<IdentityUserLogin<string>>().ToTable("tblUserLogin");
            builder.Entity<IdentityUserClaim<string>>().ToTable("tblUserClaim");
            builder.Entity<IdentityRole>().ToTable("tblRole");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("tblRoleClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("tblUserToken");
        }
    }
}
