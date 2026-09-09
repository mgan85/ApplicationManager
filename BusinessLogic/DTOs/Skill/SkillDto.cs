namespace BusinessLogic.DTOs.Skill;

public class SkillDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int LevelId { get; set; }
    public string LevelName { get; set; } = string.Empty;
}