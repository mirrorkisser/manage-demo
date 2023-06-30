    
using manage_demo.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
namespace manage_demo.Data
{



        public class DataContext : DbContext
        {
            public DbSet<UserEntity> Users { get; set; }

            public DataContext(DbContextOptions options) : base(options)
            {

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<UserEntity>().ToTable("Users");
            }
        }

}

