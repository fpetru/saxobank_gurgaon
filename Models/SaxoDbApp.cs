using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_webApp.Models
{
    public class SaxoDbAppContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        /// <summary>
        /// Read the ConenctionString from appsettings.json
        /// when the class is registered in IServiceCollection in StartUp Class
        ///from StartUp.cs
        /// </summary>
        /// <param name="options"></param>
        public SaxoDbAppContext(DbContextOptions<SaxoDbAppContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); // Perform Default Operations for Object-to-table mapping
        }
    }
}
