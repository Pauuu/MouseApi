using Microsoft.EntityFrameworkCore;
using MouseApi.Models;

namespace Data.MouseApiContext
{
    public class MouseDbContext : DbContext
    {
        public MouseDbContext(DbContextOptions<MouseDbContext> options) : base(options) { }

        public DbSet<MouseItem> MouseItems { get; set; }
    }
}