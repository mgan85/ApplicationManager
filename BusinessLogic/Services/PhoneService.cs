using BusinessLogic.DTOs.Phone;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using DataLogic.Entities;
using DataLogic.Repositories;

namespace BusinessLogic.Services;

public class PhoneService(IPhoneRepository repository) : IPhoneService
{
    private readonly IPhoneRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<int> CreatePhoneAsync(PhoneDto dto)
    {
        var entity = new Phone
        {
            Number = dto.Number
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return entity.Id;
    }

    public async Task UpdatePhoneAsync(PhoneDto dto)
    {
        var entity = await _repository.GetByIdAsync(dto.Id) ?? throw new NotFoundException("Phone not found");

        entity.Number = dto.Number;
        await _repository.SaveChangesAsync();
    }
}
