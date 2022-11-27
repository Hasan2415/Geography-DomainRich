using Geography.Domain.Cities.Contracts;
using Geography.Domain.Cities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Geography.SqlServer.Cities;

public class EFCityQueryRepository : CityQueryRepository
{
    private readonly EFDataContext _context;

    public EFCityQueryRepository(EFDataContext context)
    {
        _context = context;
    }

    public async Task<GetCityDetailDto?> Get(int id)
    {
        return await _context.Cities
            .Where(_ => _.Id == id)
            .Select(_ => new GetCityDetailDto
            {
                Name = _.Name,
                ProvinceId = _.ProvinceId
            }).SingleOrDefaultAsync();
    }

    public async Task<List<GetAllCityDto>> GetAll(int provinceId)
    {
        return await _context.Cities
            .Where(_=>_.ProvinceId == provinceId)
            .Select(_ => new GetAllCityDto
            {
                Name = _.Name,
                ProvinceId = _.ProvinceId
            }).ToListAsync();
    }
}