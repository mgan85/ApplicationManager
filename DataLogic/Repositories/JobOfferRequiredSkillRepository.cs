using DataLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLogic.Repositories;
public interface IJobOfferRequiredSkillRepository
{
    Task AddAsync(int jobOfferId, int skillId);
    Task<bool> RemoveAsync(int jobOfferId, int skillId);
    Task<List<Skill>> GetRequiredSkillsForOfferAsync(int jobOfferId);
    Task SaveChangesAsync();
}

public class JobOfferRequiredSkillRepository(ApplicationDbContext context) : IJobOfferRequiredSkillRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(int jobOfferId, int skillId)
    {
        var requiredSkill = new JobOfferRequiredSkill { JobOfferId = jobOfferId, SkillId = skillId };
        await _context.JobOfferRequiredSkills.AddAsync(requiredSkill);
    }

    public async Task<bool> RemoveAsync(int jobOfferId, int skillId)
    {
        var requiredSkill = await _context.JobOfferRequiredSkills.FindAsync(jobOfferId, skillId);
        if (requiredSkill == null) return false;

        _context.JobOfferRequiredSkills.Remove(requiredSkill);
        return true;
    }

    public async Task<List<Skill>> GetRequiredSkillsForOfferAsync(int jobOfferId)
    {
        return await _context.JobOfferRequiredSkills
            .Where(jrs => jrs.JobOfferId == jobOfferId)
            .Select(jrs => jrs.Skill)
            .Include(s => s.Level)
            .ToListAsync();
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
