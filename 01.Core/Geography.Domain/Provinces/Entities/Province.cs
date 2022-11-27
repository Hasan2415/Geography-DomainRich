using Geography.Domain.Provinces.ValueObjects;

namespace Geography.Domain.Provinces.Entities;

public class Province : BaseEntity<int>
{
    public ProvinceName Name { get; private set; } = default!;
    
    private Province(ProvinceName name)
    {
        Name = name;
    }

    public static Province Create(ProvinceName name)
    {
        return new Province(name);
    }
}