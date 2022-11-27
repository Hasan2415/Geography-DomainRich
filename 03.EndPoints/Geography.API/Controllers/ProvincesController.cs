using Geography.Domain.Provinces.Contracts;
using Geography.Domain.Provinces.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Geography.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProvincesController : ControllerBase
{
    [HttpPost]
    public async Task Add(
        [FromBody] AddProvinceDto dto,
        [FromServices] AddProvinceHandler handler)
    {
        await handler.Handle(dto);
    }
}