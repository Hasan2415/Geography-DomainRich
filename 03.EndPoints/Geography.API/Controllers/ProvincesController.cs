using Geography.Domain.Provinces.Contracts;
using Geography.Domain.Provinces.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Geography.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProvincesController : ControllerBase
{
    private readonly ProvinceQueryRepository _provinceQueryRepository;

    public ProvincesController(ProvinceQueryRepository provinceQueryRepository)
    {
        _provinceQueryRepository = provinceQueryRepository;
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
}