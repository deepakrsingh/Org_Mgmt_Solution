using Microsoft.EntityFrameworkCore;
using OMSWeb.Modelsl;

namespace OMSWeb.Data;

public class OrgDbContext : DbContext
{
    public OrgDbContext(DbContextOptions<OrgDbContext> options) : base(options) { }

    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .ToTable("Persons");

        base.OnModelCreating(modelBuilder);
    }
}
