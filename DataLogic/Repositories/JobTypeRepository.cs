using DataLogic.Entities;

namespace DataLogic.Repositories;
public interface IJobTypeRepository : IRepository<JobType> { }

public class JobTypeRepository(ApplicationDbContext context) : Repository<JobType>(context), IJobTypeRepository
{
}