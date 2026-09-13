using BusinessLogic.DTOs.Address;
using BusinessLogic.DTOs.User;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using DataLogic.Entities;
using DataLogic.Repositories;

namespace BusinessLogic.Services;

public class UserService (IUserRepository repository) : IUserService
{
    private readonly IUserRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<int> CreateUserAsync(UserDto dto)
    {
        var entity = new User
        {
            Id = dto.Id,
            AddressId = dto.Address?.Id,
            Name = dto.Name,
            Surname = dto.Surname
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return entity.Id;
    }

    public async Task UpdateUserAsync(UserDto dto)
    {
        var entity = await _repository.GetByIdAsync(dto.Id) ?? throw new NotFoundException("User not found");

        entity.Name = dto.Name;
        entity.Surname = dto.Surname;
        entity.AddressId = dto.Address?.Id;

        await _repository.SaveChangesAsync();
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id) ?? throw new NotFoundException("User not found");

        return new UserDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            Address = entity.Address != null ? new AddressDto
            {
                Id = entity.Address.Id,
                Line1 = entity.Address.Line1,
                Line2 = entity.Address.Line2,
                Line3 = entity.Address.Line3,
                City = entity.Address.City,
                Postcode = entity.Address.Postcode
            } : null
        };
    }

    public async Task<List<UserDto>> GetUsersListAsync(int id)
    {
        var entities = await _repository.GetAllAsync() ?? throw new NotFoundException("Users not found");

        return [.. entities.Select(entity => new UserDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            Address = entity.Address != null ? new AddressDto
            {
                Id = entity.Address.Id,
                Line1 = entity.Address.Line1,
                Line2 = entity.Address.Line2,
                Line3 = entity.Address.Line3,
                City = entity.Address.City,
                Postcode = entity.Address.Postcode
            } : null
        })];
    }
}
