using DataLogic.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataLogic.Repositories;

public interface IAddressRepository : IRepository<Address>
{
    Task<Address> GetAddressByIdAsync(int id);
    Task<Address> GetAddressByUserIdAsync(int userId);
}

public class AddressRepository(ApplicationDbContext context) : Repository<Address>(context), IAddressRepository
{
    public async Task<Address> GetAddressByIdAsync(int id)
    {
        var address = await _dbSet.FindAsync(id);

        return address ?? throw new KeyNotFoundException($"Address with ID {id} not found.");
    }

    public async Task<Address> GetAddressByUserIdAsync(int userId)
    {
        var address = await _dbSet.FirstOrDefaultAsync(a => a.Id == userId);
        
        return address ?? throw new KeyNotFoundException($"Address for User ID {userId} not found.");
    }

}
