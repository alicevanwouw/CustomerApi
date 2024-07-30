using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Security;
using System.Text.RegularExpressions;


namespace CustomerApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }

    }
}
