using Geography.Domain.Provinces.Exceptions;

namespace Geography.Domain.Provinces.ValueObjects;

public class ProvinceName
{
    public string _value { get; private set; }

    public static ProvinceName FromString(string name) => new ProvinceName(name);

    private ProvinceName()
    {
    }

    public ProvinceName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ProvinceNameIsRequiredException();
        }

        _value = value;
    }

    public static implicit operator string(ProvinceName name) => name._value;
}