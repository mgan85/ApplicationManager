using DataLogic.Entities;

namespace DataLogic.Repositories;
public interface IApplicationStatusRepository : IRepository<ApplicationStatus> { }

public class ApplicationStatusRepository(ApplicationDbContext context) : Repository<ApplicationStatus>(context), IApplicationStatusRepository
{
}
