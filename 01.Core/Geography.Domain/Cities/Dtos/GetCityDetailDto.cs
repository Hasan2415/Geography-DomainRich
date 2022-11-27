namespace Geography.Domain.Cities.Dtos;

public class GetCityDetailDto
{
    public string Name { get; set; } = default!;
    public int ProvinceId { get; set; }
}