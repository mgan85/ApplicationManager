using BusinessLogic.DTOs.Address;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using DataLogic.Entities;
using DataLogic.Repositories;

namespace BusinessLogic.Services;

public class AddressService(IAddressRepository repository) : IAddressService
{
    private readonly IAddressRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<int> CreateAddressAsync(AddressDto dto)
    {
        var entity = new Address
        {
            Line1 = dto.Line1,
            Line2 = dto.Line2,
            Line3 = dto.Line3,
            City = dto.City,
            Postcode = dto.Postcode
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<int> UpdateAddressAsync(AddressDto dto)
    {
        var entity = await _repository.GetByIdAsync(dto.Id) ?? throw new NotFoundException("Address not found");

        entity.Line1 = dto.Line1;
        entity.Line2 = dto.Line2;
        entity.Line3 = dto.Line3;
        entity.City = dto.City;
        entity.Postcode = dto.Postcode;


        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<AddressDto> GetAddressByIdAsync(int id)
    {
        var entity = await _repository.GetAddressByIdAsync(id) ?? throw new NotFoundException("Address not found");
        return new AddressDto
        {
            Id = entity.Id,
            Line1 = entity.Line1,
            Line2 = entity.Line2,
            Line3 = entity.Line3,
            City = entity.City,
            Postcode = entity.Postcode
        };
    }
}