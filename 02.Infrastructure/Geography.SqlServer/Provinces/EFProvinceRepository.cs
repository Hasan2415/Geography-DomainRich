using Geography.Domain.Provinces.Contracts;
using Geography.Domain.Provinces.Entities;
using Microsoft.EntityFrameworkCore;

namespace Geography.SqlServer.Provinces;

public class EFProvinceRepository : ProvinceRepository
{
    private readonly EFDataContext _context;

    public EFProvinceRepository(EFDataContext context)
    {
        _context = context;
    }

    public void Add(Province province)
    {
        _context.Provinces.Add(province);
    }

    public async Task<bool> IsExist(string name)
    {
        return await _context.Provinces
            .AnyAsync(_ => _.Name == name);
    }

    public async Task<bool> IsExist(int id)
    {
        return await _context.Provinces
            .AnyAsync(_ => _.Id == id);
    }
}