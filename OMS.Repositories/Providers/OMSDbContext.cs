using Microsoft.EntityFrameworkCore;
using OMS.Repository.Models;

namespace OMS.Repository
{
    public class OMSDbContext : DbContext
    {
        private readonly string _connectionString;

        public OMSDbContext()
        {
            
        }
        public OMSDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public OMSDbContext(DbContextOptions<OMSDbContext> options): base(options)
        {
        }

        public DbSet<BusinessEntity> BusinessEntities { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(_connectionString))
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
            if (!optionsBuilder.IsConfigured)
            {
                // Configure the context to use a specific database provider
                optionsBuilder
                .UseSqlServer(Constants.DbConnectionString,
                             providerOptions => { providerOptions.EnableRetryOnFailure(); })
                .UseSeeding((context, _) =>
                {
                    //context.Database.EnsureCreated();

                    context.Set<AddressType>().AddRange(new List<AddressType>
                    {
                        new AddressType { Name = "Home", ModifiedDate = DateTime.Now },
                        new AddressType { Name = "Work", ModifiedDate = DateTime.Now },
                        new AddressType { Name = "Billing", ModifiedDate = DateTime.Now }
                    });

                    context.Set<Country>().AddRange(new List<Country>
                    {
                        new Country { CountryCode = "CA", CountryName = "Canada", ModifiedDate = DateTime.Now },
                        new Country { CountryCode = "IN", CountryName = "India", ModifiedDate = DateTime.Now },
                        new Country { CountryCode = "US", CountryName = "United States", ModifiedDate = DateTime.Now }
                    });

                    context.Set<State>().AddRange(new List<State>
                    {
                        new State { StateName = "Ontario", CountryId = 1, ModifiedDate = DateTime.Now },
                        new State { StateName = "Arunachal Pradesh", CountryId = 2, ModifiedDate = DateTime.Now },
                        new State { StateName = "Bihar", CountryId = 2, ModifiedDate = DateTime.Now },
                        new State { StateName = "Himachal Pradesh", CountryId = 2, ModifiedDate = DateTime.Now },
                        new State { StateName = "Goa", CountryId = 2, ModifiedDate = DateTime.Now },
                        new State { StateName = "Maharashtra", CountryId = 2, ModifiedDate = DateTime.Now },
                        new State { StateName = "Uttar Pradesh", CountryId = 2, ModifiedDate = DateTime.Now },
                        new State { StateName = "California", CountryId = 3, ModifiedDate = DateTime.Now }
                    });

                    context.Set<BusinessEntity>().AddRange(new List<BusinessEntity>
                    {
                        new BusinessEntity { BusinessName = "Tech Solutions", BusinessType = "IT Services", ModifiedDate = DateTime.Now },
                        new BusinessEntity { BusinessName = "Green Energy Corp", BusinessType = "Renewable Energy", ModifiedDate = DateTime.Now },
                        new BusinessEntity { BusinessName = "HealthPlus", BusinessType = "Healthcare Services", ModifiedDate = DateTime.Now }
                    });


                    context.SaveChanges();
                })
                .UseAsyncSeeding((context, _, CancellationToken) =>
                {
                    context.Database.EnsureCreated();

                    context.Set<AddressType>().AddRange(new List<AddressType>
                    {
                        new AddressType { Name = "Home", ModifiedDate = DateTime.Now },
                        new AddressType { Name = "Work", ModifiedDate = DateTime.Now },
                        new AddressType { Name = "Billing", ModifiedDate = DateTime.Now }
                    });
                    context.Set<Country>().AddRange(new List<Country>
                    {
                        new Country { CountryCode = "CA", CountryName = "Canada", ModifiedDate = DateTime.Now },
                        new Country { CountryCode = "IN", CountryName = "India", ModifiedDate = DateTime.Now },
                        new Country { CountryCode = "US", CountryName = "United States", ModifiedDate = DateTime.Now }
                    });

                    context.Set<State>().AddRange(new List<State>
                    {
                        new State { StateName = "Ontario", CountryId = 1, ModifiedDate = DateTime.Now },
                        new State { StateName = "Arunachal Pradesh", CountryId = 2, ModifiedDate = DateTime.Now },
                        new State { StateName = "Bihar", CountryId = 2, ModifiedDate = DateTime.Now },
                        new State { StateName = "Himachal Pradesh", CountryId = 2, ModifiedDate = DateTime.Now },
                        new State { StateName = "Goa", CountryId = 2, ModifiedDate = DateTime.Now },
                        new State { StateName = "Maharashtra", CountryId = 2, ModifiedDate = DateTime.Now },
                        new State { StateName = "Uttar Pradesh", CountryId = 2, ModifiedDate = DateTime.Now },
                        new State { StateName = "California", CountryId = 3, ModifiedDate = DateTime.Now }
                    });

                    context.Set<BusinessEntity>().AddRange(new List<BusinessEntity>
                    {
                        new BusinessEntity { BusinessName = "Tech Solutions", BusinessType = "IT Services", ModifiedDate = DateTime.Now },
                        new BusinessEntity { BusinessName = "Green Energy Corp", BusinessType = "Renewable Energy", ModifiedDate = DateTime.Now },
                        new BusinessEntity { BusinessName = "HealthPlus", BusinessType = "Healthcare Services", ModifiedDate = DateTime.Now }
                    });
                    return context.SaveChangesAsync(CancellationToken);
                })
                .EnableSensitiveDataLogging();
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entity mappings here

        }
     }
}
