using DataLogic.Entities;

namespace DataLogic.Repositories;
public interface ISkillLevelRepository : IRepository<SkillLevel> { }

public class SkillLevelRepository(ApplicationDbContext context) : Repository<SkillLevel>(context), ISkillLevelRepository
{
}