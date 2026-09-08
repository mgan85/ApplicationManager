using Microsoft.EntityFrameworkCore;
using DataLogic.Entities;

namespace DataLogic.Repositories;
public interface IApplicationRepository : IRepository<Application>
{
    Task<List<Application>> GetApplicationsByUserIdAsync(int userId);
    Task<Application?> GetFullApplicationDetailsAsync(int id);
}

public class ApplicationRepository(ApplicationDbContext context) : Repository<Application>(context), IApplicationRepository
{
    public async Task<List<Application>> GetApplicationsByUserIdAsync(int userId)
    {
        return await _dbSet
            .Where(a => a.UserId == userId)
            .Include(a => a.Status)
            .Include(a => a.JobOffer)
            .ToListAsync();
    }

    public async Task<Application?> GetFullApplicationDetailsAsync(int id)
    {
        return await _dbSet
            .Include(a => a.Status)
            .Include(a => a.User)
            .Include(a => a.JobOffer)
            .Include(a => a.Handler)
                .ThenInclude(h => h!.Phone)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}