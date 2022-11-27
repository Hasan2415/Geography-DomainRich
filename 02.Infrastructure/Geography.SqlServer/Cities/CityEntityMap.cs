using Geography.Domain.Cities.Entities;
using Geography.Domain.Cities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geography.SqlServer.Cities;

public class CityEntityMap : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> _)
    {
        _.ToTable("Cities");
        _.HasKey(q => q.Id);
        
        _.Property(q => q.Name)
            .HasConversion(
                w => w._value,
                r => CityName.FromString(r));

        _.Property(q => q.ProvinceId)
            .HasConversion(
                w => w._value,
                r => ProvinceId.FromInt(r));
    }
}