using Geography.Domain.Provinces.Contracts;
using Geography.Domain.Provinces.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Geography.SqlServer.Provinces;

public class EFProvinceQueryRepository : ProvinceQueryRepository
{
    private readonly EFDataContext _context;

    public EFProvinceQueryRepository(EFDataContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllProvinceDto>> GetAll()
    {
        return await _context.Provinces
            .Select(_ => new GetAllProvinceDto
            {
                Id = _.Id,
                Name = _.Name
            }).ToListAsync();
    }
}