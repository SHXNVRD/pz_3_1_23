using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-JT57IK1E\SQLEXPRESS;Database=pz3_3.db;Trusted_Connection=True;TrustServerCertificate=True;");
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
