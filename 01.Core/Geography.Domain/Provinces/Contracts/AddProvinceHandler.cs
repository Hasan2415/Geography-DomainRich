using Geography.Domain.Provinces.Dtos;

namespace Geography.Domain.Provinces.Contracts;

public interface AddProvinceHandler
{
    Task Handle(AddProvinceDto dto);
}