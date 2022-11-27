using Geography.Domain.Cities.Contracts;
using Geography.Domain.Cities.Dtos;
using Geography.Domain.Provinces.Contracts;
using Geography.Domain.Provinces.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Geography.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProvincesController : ControllerBase
{
    private readonly ProvinceQueryRepository _provinceQueryRepository;
    private readonly CityQueryRepository _cityQueryRepository;

    public ProvincesController(
        ProvinceQueryRepository provinceQueryRepository,
        CityQueryRepository cityQueryRepository)
    {
        _provinceQueryRepository = provinceQueryRepository;
        _cityQueryRepository = cityQueryRepository;
    }

    [HttpPost]
    public async Task Add(
        [FromBody] AddProvinceDto dto,
        [FromServices] AddProvinceHandler handler)
    {
        await handler.Handle(dto);
    }

    [HttpGet]
    public async Task<List<GetAllProvinceDto>> GetAll()
    {
        return await _provinceQueryRepository.GetAll();
    }

    [HttpGet("{id}/details")]
    public async Task<GetProvinceDetailsDto?> GetDetails(int id)
    {
        return await _provinceQueryRepository.GetDetails(id);
    }

    [HttpGet("{id}/cities")]
    public async Task<List<GetAllCityDto>> GetAllCities(int id)
    {
        return await _cityQueryRepository.GetAll(id);
    }
}