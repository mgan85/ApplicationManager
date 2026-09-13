using BusinessLogic.DTOs.Skill;

namespace BusinessLogic.Interfaces
{
    public interface ISkillService
    {
        Task<int> CreateSkillAsync(SkillDto dto);
        Task UpdateSkillAsync(SkillDto dto);
        Task<SkillDto> GetSkillByIdAsync(int id);
        Task DeleteSkillAsync(int id);
    }
}
