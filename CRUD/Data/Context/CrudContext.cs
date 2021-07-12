using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data.Context
{
    public class CrudContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }

        public CrudContext(DbContextOptions<CrudContext> options) : base(options) { }
    }
}