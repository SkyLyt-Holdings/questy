using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Questy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questy.Data
{
    public class QuestyContext : DbContext
    {
        private string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Questy_DEV";

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTypePermissions>().HasKey(utp => new { utp.UserTypeID, utp.PermissionID });
        }
    }
}
