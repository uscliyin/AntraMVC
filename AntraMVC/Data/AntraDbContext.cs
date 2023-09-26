using AntraMVC.Models.Domain;
using Microsoft.EntityFrameworkCore;
using AntraMVC.Models.Account;

namespace AntraMVC.Data
{
    public class AntraDbContext : DbContext
    {
        public AntraDbContext(DbContextOptions<AntraDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<AntraMVC.Models.Account.Register>? Register { get; set; }
    }
}
