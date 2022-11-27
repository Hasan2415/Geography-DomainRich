using Geography.Domain.Provinces.Dtos;

namespace Geography.Domain.Provinces.Contracts;

public interface ProvinceQueryRepository
{
    Task<List<GetAllProvinceDto>> GetAll();
    Task<GetProvinceDetailsDto?> GetDetails(int id);
}