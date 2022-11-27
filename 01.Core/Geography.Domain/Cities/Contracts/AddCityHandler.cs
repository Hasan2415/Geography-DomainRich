using Geography.Domain.Cities.Dtos;

namespace Geography.Domain.Cities.Contracts;

public interface AddCityHandler
{
    Task Handle(AddCityDto dto);
}