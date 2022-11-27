using Geography.Domain.Cities.Entities;
using Geography.Domain.Provinces.Entities;
using Microsoft.EntityFrameworkCore;

namespace Geography.SqlServer;

public class EFDataContext : DbContext
{
    public DbSet<Province> Provinces { get; set; }
    public DbSet<City> Cities { get; set; }

    public EFDataContext(DbContextOptions<EFDataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}