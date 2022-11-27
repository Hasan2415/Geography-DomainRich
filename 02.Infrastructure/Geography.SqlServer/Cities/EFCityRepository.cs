using Geography.Domain.Cities.Contracts;
using Geography.Domain.Cities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Geography.SqlServer.Cities;

public class EFCityRepository : CityRepository
{
    private readonly EFDataContext _context;

    public EFCityRepository(EFDataContext context)
    {
        _context = context;
    }

    public void Add(City city)
    {
        _context.Cities.Add(city);
    }

    public async Task<bool> IsExist(string name)
    {
        return await _context.Cities
            .AnyAsync(_ => _.Name == name);
    }
}