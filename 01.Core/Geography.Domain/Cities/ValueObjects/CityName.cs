using Geography.Domain.Cities.Exceptions;

namespace Geography.Domain.Cities.ValueObjects;

public class CityName
{
    public string _value { get; private set; }

    public static CityName FromString(string value) => new CityName(value);

    public CityName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new CityNameIsRequiredException();
        }

        _value = value;
    }

    public static implicit operator string(CityName cityName) => cityName._value;
}