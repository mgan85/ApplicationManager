using DataLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLogic.Repositories;
public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserWithDetailsAsync(int id);
}

public class UserRepository(ApplicationDbContext context) : Repository<User>(context), IUserRepository
{
    public async Task<User?> GetUserWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(u => u.Address)
            .Include(u => u.UserSkills)
                .ThenInclude(us => us.Skill)
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}