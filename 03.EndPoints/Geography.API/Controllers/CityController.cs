using Geography.Domain.Cities.Contracts;
using Geography.Domain.Cities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Geography.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    private readonly CityQueryRepository _repository;

    public CityController(CityQueryRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task Add(
        [FromBody] AddCityDto dto,
        [FromServices] AddCityHandler handler)
    {
        await handler.Handle(dto);
    }

    [HttpGet("{id}/details")]
    public async Task<GetCityDetailDto?> Get(int id)
    {
        return await _repository.Get(id);
    }
}