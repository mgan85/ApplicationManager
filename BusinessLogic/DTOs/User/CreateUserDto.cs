namespace BusinessLogic.DTOs.User;

public class CreateUserDto
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int? AddressId { get; set; }
    public List<int> SkillIds { get; set; } = new();
}