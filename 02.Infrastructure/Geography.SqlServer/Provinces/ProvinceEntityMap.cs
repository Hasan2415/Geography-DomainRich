using Geography.Domain.Provinces.Entities;
using Geography.Domain.Provinces.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Geography.SqlServer.Provinces;

public class ProvinceEntityMap : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> _)
    {
        _.ToTable("Provinces");
        _.HasKey(q => q.Id);
        _.Property(q => q.Name)
            .HasConversion(
                w => w._value,
                r => ProvinceName.FromString(r));
    }
}