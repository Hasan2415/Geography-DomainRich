using Geography.Domain.Cities.Dtos;

namespace Geography.Domain.Cities.Contracts;

public interface CityQueryRepository
{
    Task<List<GetAllCityDto>> GetAll(int provinceId);
}