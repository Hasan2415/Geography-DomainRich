using Geography.Domain.Cities.ValueObjects;

namespace Geography.Domain.Cities.Entities;

public class City : BaseEntity<int>
{
    public CityName Name { get; set; } = default!;
    public ProvinceId ProvinceId { get; set; } = default!;

    private City(
        CityName name,
        ProvinceId provinceId)
    {
        Name = name;
        ProvinceId = provinceId;
    }

    public static City Create(
        CityName name,
        ProvinceId provinceId)
    {
        return new City(name, provinceId);
    }
}