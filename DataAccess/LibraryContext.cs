using System;
using IDataInterface;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class LibraryContext : DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Library;Trusted_connection=true");

        }

        public DbSet<Isle> Isles { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Customer> Customers { get; set;}

    }
}
