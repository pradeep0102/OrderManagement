using Microsoft.EntityFrameworkCore;
using OrderManagement.Shared.Entities;

namespace OrderManagement.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Supplier> Suppliers { get; set; }

    }
}
