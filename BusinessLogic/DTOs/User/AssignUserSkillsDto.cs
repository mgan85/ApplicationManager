namespace BusinessLogic.DTOs.User;

public class AssignUserSkillsDto
{
    public int UserId { get; set; }
    public List<int> SkillIds { get; set; } = new();
}
