using BusinessLogic.DTOs.JobOffer;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using DataLogic.Entities;
using DataLogic.Repositories;

namespace BusinessLogic.Services;

public class JobOfferService (IJobOfferRepository repository) : IJobOfferService
{
    private readonly IJobOfferRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<int> CreateJobOfferAsync(JobOfferDto dto)
    {
        var entity = new JobOffer
        {
            Title = dto.Title,
            Description = dto.Description,
            CompanyName = dto.CompanyName,
            Salary = dto.Salary,
            Platform = dto.Platform,
            JobTypeId = dto.JobType?.Id
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return entity.Id;
    }

    public async Task UpdateJobOfferAsync(JobOfferDto dto)
    {
        var entity = await _repository.GetByIdAsync(dto.Id) ?? throw new NotFoundException("Job offer not found");
        
        entity.Title = dto.Title;
        entity.Description = dto.Description;
        entity.CompanyName = dto.CompanyName;
        entity.Salary = dto.Salary;
        entity.Platform = dto.Platform;
        entity.JobTypeId = dto.JobType?.Id;

        await _repository.SaveChangesAsync();
    }
}
