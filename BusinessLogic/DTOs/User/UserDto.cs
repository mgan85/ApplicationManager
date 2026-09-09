using BusinessLogic.DTOs.Address;

namespace BusinessLogic.DTOs.User;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public AddressDto? Address { get; set; }
    public List<UserSkillDto> Skills { get; set; } = new();
}
