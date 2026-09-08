using DataLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLogic.Repositories;
public interface IUserSkillRepository
{
    Task AddAsync(int userId, int skillId);
    Task<bool> RemoveAsync(int userId, int skillId);
    Task<List<Skill>> GetSkillsForUserAsync(int userId);
    Task SaveChangesAsync();
}

public class UserSkillRepository(ApplicationDbContext context) : IUserSkillRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(int userId, int skillId)
    {
        var userSkill = new UserSkill { UserId = userId, SkillId = skillId };
        await _context.UserSkills.AddAsync(userSkill);
    }

    public async Task<bool> RemoveAsync(int userId, int skillId)
    {
        var userSkill = await _context.UserSkills.FindAsync(userId, skillId);
        if (userSkill == null) return false;

        _context.UserSkills.Remove(userSkill);
        return true;
    }

    public async Task<List<Skill>> GetSkillsForUserAsync(int userId)
    {
        return await _context.UserSkills
            .Where(us => us.UserId == userId)
            .Select(us => us.Skill)
            .Include(s => s.Level)
            .ToListAsync();
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}