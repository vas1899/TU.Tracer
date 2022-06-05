using Microsoft.EntityFrameworkCore;
using Domain;


namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {
        }

        public DbSet<Workday> Workdays { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
