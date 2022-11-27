using Geography.Domain.Cities.Dtos;

namespace Geography.Domain.Cities.Contracts;

public interface CityQueryRepository
{
    Task<GetCityDetailDto?> Get(int id);
    Task<List<GetAllCityDto>> GetAll(int provinceId);
}