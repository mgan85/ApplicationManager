using DataLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLogic.Repositories;
public interface ISkillRepository : IRepository<Skill>
{
    Task<List<Skill>> GetSkillsWithLevelAsync();
}

public class SkillRepository(ApplicationDbContext context) : Repository<Skill>(context), ISkillRepository
{
    public async Task<List<Skill>> GetSkillsWithLevelAsync()
    {
        return await _dbSet
            .Include(s => s.Level)
            .ToListAsync();
    }
}
