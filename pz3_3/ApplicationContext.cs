using Microsoft.EntityFrameworkCore;

namespace pz3_3
{
    internal class ApplicationContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Sex> Sexes { get; set; }
        public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-JT57IK1E\SQLEXPRESS; Database=pz3_3.db; Trusted_Connection=True; TrustServerCertificate=True;");
        }
    }
}
