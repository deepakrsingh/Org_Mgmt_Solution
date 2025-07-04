using Microsoft.EntityFrameworkCore;
using OMSWeb.Modelsl;

namespace OMSWeb.Data;

public class OrgDbContext : DbContext
{
    public OrgDbContext(DbContextOptions<OrgDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .ToTable("Employees");

        base.OnModelCreating(modelBuilder);
    }
}
