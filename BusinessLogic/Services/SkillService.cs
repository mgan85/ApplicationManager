using BusinessLogic.DTOs.Skill;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using DataLogic.Entities;
using DataLogic.Repositories;

namespace BusinessLogic.Services;

public class SkillService (ISkillRepository repository) : ISkillService
{
    private readonly ISkillRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<int> CreateSkillAsync(SkillDto dto)
    {
        var entity = new Skill
        {
            Name = dto.Name,
            LevelId = dto.LevelId
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return entity.Id;
    }

    public async Task UpdateSkillAsync(SkillDto dto)
    {
        var entity = await _repository.GetByIdAsync(dto.Id) ?? throw new NotFoundException("Skill not found");
        entity.Name = dto.Name;
        entity.LevelId = dto.LevelId;

        await _repository.SaveChangesAsync();
    }

    public async Task<SkillDto> GetSkillByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id) ?? throw new NotFoundException("Skill not found");

        return new SkillDto
        {
            Id = entity.Id,
            Name = entity.Name,
            LevelId = entity.LevelId
        };
    }

    public async Task DeleteSkillAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id) ?? throw new NotFoundException("Skill not found");
        _repository.Remove(entity);
        await _repository.SaveChangesAsync();
    }
}
