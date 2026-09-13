using BusinessLogic.DTOs.User;

namespace BusinessLogic.Interfaces;

public interface IUserService
{
    Task<int> CreateUserAsync(UserDto dto);
    Task UpdateUserAsync(UserDto dto);
    Task<UserDto> GetUserByIdAsync(int id);
    Task<List<UserDto>> GetUsersListAsync(int id);
}
