namespace Geography.Domain.Cities.ValueObjects;

public class ProvinceId
{
    public int _value { get; private set; }
    
    public static ProvinceId FromInt(int value) => new ProvinceId(value);

    public ProvinceId(int value)
    {
        _value = value;
    }

    public static implicit operator int(ProvinceId provinceId) => provinceId._value;
}