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
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkdayEmployee> WorkdayEmployees { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<WorkdayEmployee>().HasKey(we => new { we.EmployeeId, we.WorkdayId });
            builder.Entity<WorkdayEmployee>().HasOne(w => w.Workday)
                .WithMany(w => w.WorkdayEmployees)
                .HasForeignKey(we => we.WorkdayId);
            builder.Entity<WorkdayEmployee>().HasOne(e => e.Employee)
                .WithMany(e => e.WorkdayEmployees)
                .HasForeignKey(we => we.EmployeeId);
        }

    }
}
