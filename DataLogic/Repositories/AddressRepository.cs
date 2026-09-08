using System;
using DataLogic.Entities;


namespace DataLogic.Repositories;

public interface IAddressRepository : IRepository<Address> { }

public class AddressRepository(ApplicationDbContext context) : Repository<Address>(context), IAddressRepository
{
}
