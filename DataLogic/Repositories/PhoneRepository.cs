using DataLogic.Entities;

namespace DataLogic.Repositories;
public interface IPhoneRepository : IRepository<Phone> { }

public class PhoneRepository(ApplicationDbContext context) : Repository<Phone>(context), IPhoneRepository
{
}