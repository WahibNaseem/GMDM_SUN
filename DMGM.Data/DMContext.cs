using DMGM.Core.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace DMGM.Data.DBContext
{
    public class DMContext :DbContext
    {
        public DMContext(DbContextOptions options):base(options) { }

     

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                               .HasKey(u => u.Id);
        }

    }
}
