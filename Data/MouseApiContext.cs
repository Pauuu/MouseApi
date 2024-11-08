using Microsoft.EntityFrameworkCore;
using MouseApi.Models;

namespace Data.MouseApiContext
{
    public class MouseApiContext : DbContext
    {
        public MouseApiContext(DbContextOptions<MouseApiContext> options) : base(options) { }

        public DbSet<MouseItem> TodoItems { get; set; }
    }
}