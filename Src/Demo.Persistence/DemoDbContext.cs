using Core.EntityFrameworkCore;
using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.Persistence
{
    public class DemoDbContext:CoreDbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options)
        :base(options)
        {
        }

        public DbSet<Students> Students{ get; set; }
    }
}
