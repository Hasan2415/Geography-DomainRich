using Framework.Data;

namespace Geography.SqlServer;

public class EFUnitOfWork : UnitOfWork
{
    private readonly EFDataContext _context;

    public EFUnitOfWork(EFDataContext context)
    {
        _context = context;
    }

    public async Task Complete()
    {
        await _context.SaveChangesAsync();
    }
}