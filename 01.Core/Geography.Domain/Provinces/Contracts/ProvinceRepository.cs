using Geography.Domain.Provinces.Entities;

namespace Geography.Domain.Provinces.Contracts;

public interface ProvinceRepository
{
    void Add(Province province);
    Task<bool> IsExistProvinceName(string name);
}