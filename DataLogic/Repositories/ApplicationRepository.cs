using Microsoft.EntityFrameworkCore;
using DataLogic.Entities;

namespace DataLogic.Repositories;
public interface IApplicationRepository : IRepository<Application>
{
    Task<bool> UserExistsAsync(int userId);
    Task<bool> OfferExistsAsync(int offerId);

    Task<List<Application>> GetApplicationsByUserIdAsync(int userId);
    Task<Application?> GetFullApplicationDetailsAsync(int id);
}

public class ApplicationRepository(ApplicationDbContext context) : Repository<Application>(context), IApplicationRepository
{
    public async Task<bool> UserExistsAsync(int userId)
        => await _context.Users.AnyAsync(u => u.Id == userId);

    public async Task<bool> OfferExistsAsync(int offerId)
        => await _context.JobOffers.AnyAsync(j => j.Id == offerId);

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