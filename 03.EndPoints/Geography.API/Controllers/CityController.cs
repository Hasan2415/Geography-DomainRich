using Geography.Domain.Cities.Contracts;
using Geography.Domain.Cities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Geography.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    [HttpPost]
    public async Task Add(
        [FromBody] AddCityDto dto,
        [FromServices] AddCityHandler handler)
    {
        await handler.Handle(dto);
    }
}