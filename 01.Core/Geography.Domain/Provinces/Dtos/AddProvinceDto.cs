using System.ComponentModel.DataAnnotations;

namespace Geography.Domain.Provinces.Dtos;

public class AddProvinceDto
{
    [Required]
    public string Name { get; set; } = default!;
}