using DataLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLogic.Repositories;
public interface IJobOfferRepository : IRepository<JobOffer>
{
    Task<JobOffer?> GetOfferWithSkillsAndTypeAsync(int id);
}

public class JobOfferRepository(ApplicationDbContext context) : Repository<JobOffer>(context), IJobOfferRepository
{
    public async Task<JobOffer?> GetOfferWithSkillsAndTypeAsync(int id)
    {
        return await _dbSet
            .Include(j => j.JobType)
            .Include(j => j.RequiredSkills)
                .ThenInclude(rs => rs.Skill)
            .FirstOrDefaultAsync(j => j.Id == id);
    }
}