using Core.EntityFrameworkCore;
using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Persistence
{
    [DbContextName("CustomerDbContext")]
    public class CustomerDbContext : CoreDbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
        : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }
    }
}
