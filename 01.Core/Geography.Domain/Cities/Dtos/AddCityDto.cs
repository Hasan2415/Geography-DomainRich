using System.ComponentModel.DataAnnotations;

namespace Geography.Domain.Cities.Dtos;

public class AddCityDto
{
    [Required]
    public string Name { get; set; } = default!;
    [Required]
    public int ProvinceId { get; set; }
}