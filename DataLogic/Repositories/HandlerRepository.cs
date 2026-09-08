using DataLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLogic.Repositories;
public interface IHandlerRepository : IRepository<Handler>
{
    Task<Handler?> GetHandlerWithPhoneAsync(int id);
}

public class HandlerRepository(ApplicationDbContext context) : Repository<Handler>(context), IHandlerRepository
{
    public async Task<Handler?> GetHandlerWithPhoneAsync(int id)
    {
        return await _dbSet
            .Include(h => h.Phone)
            .FirstOrDefaultAsync(h => h.Id == id);
    }
}