using Microsoft.EntityFrameworkCore;
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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: connectionString);
        }
    }
}
