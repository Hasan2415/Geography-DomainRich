using Geography.Domain.Cities.Entities;

namespace Geography.Domain.Cities.Contracts;

public interface CityRepository
{
    void Add(City city);
    Task<bool> IsExist(string name);
}