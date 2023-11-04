using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace pz4_1
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() => Database.EnsureCreated();

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) =>
            Database.EnsureCreatedAsync();
            

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(GetUsers());
        }

        private User[] GetUsers()
        {
            return new User[]
            {
                new User {Id = 1, Name = "Иван", Birthday = new DateTime(2012, 12, 12) ,Phone = "+784361246133", Address = "г. Москва, ул. Пушкина, д. Колотушкина"}
            };
        }
    }
}
