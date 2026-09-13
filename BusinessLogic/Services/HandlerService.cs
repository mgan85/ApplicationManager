using BusinessLogic.DTOs.Handler;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using DataLogic.Entities;
using DataLogic.Repositories;

namespace BusinessLogic.Services;

public class HandlerService (IHandlerRepository repository, IPhoneService phoneService) : IHandlerService
{
    private readonly IHandlerRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IPhoneService _phoneService = phoneService ?? throw new ArgumentNullException(nameof(phoneService));

    public async Task<int> CreateHandleAsync(HandlerDto dto)
    {

        int phoneId = await _phoneService.CreatePhoneAsync(dto.Phone);

        var entity = new Handler
        {
            Name = dto.Name,
            Email = dto.Email,
            PhoneId = phoneId
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return entity.Id;
    }

    public async Task UpdateHandleAsync(HandlerDto dto)
    {
        var entity = await _repository.GetByIdAsync(dto.Id) ?? throw new NotFoundException("Handler not found");
        entity.Name = dto.Name;
        entity.Email = dto.Email;

        if (dto.Phone != null)
        {
            await _phoneService.UpdatePhoneAsync(dto.Phone);
        }

        await _repository.SaveChangesAsync();
    }

    public async Task DeleteHandlerAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id) ?? throw new NotFoundException("Handler not found");
        
        _repository.Remove(entity);
        await _repository.SaveChangesAsync();
    }
}
