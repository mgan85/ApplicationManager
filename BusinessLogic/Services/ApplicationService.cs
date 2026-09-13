using BusinessLogic.DTOs.Application;
using BusinessLogic.Enums;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using DataLogic.Entities;
using DataLogic.Repositories;

namespace BusinessLogic.Services;

public class ApplicationService(IApplicationRepository repository) : IApplicationService
{
    private readonly IApplicationRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    public async Task<int> CreateApplicationAsync(CreateApplicationDto dto)
    {
        var userExists = await _repository.UserExistsAsync(dto.UserId);
        if (!userExists)
            throw new NotFoundException($"User with Id {dto.UserId} not found.");

        var offerExists = await _repository.OfferExistsAsync(dto.JobOfferId);
        if (!offerExists)
            throw new NotFoundException($"Job offer with Id {dto.JobOfferId} not found.");

        var entity = new Application
        {
            UserId = dto.UserId,
            JobOfferId = dto.JobOfferId,
            HandlerId = dto.HandlerId,
            StatusId = (int)ApplicationStatusEnum.Draft
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return entity.Id;
    }

    public async Task SubmitApplicationAsync(int applicationId)
    {
        var application = await _repository.GetByIdAsync(applicationId) ?? throw new NotFoundException($"Application with Id {applicationId} not found.");
        application.ApplyDate = DateTime.UtcNow;
        application.StatusId = (int)ApplicationStatusEnum.Submitted;

        await _repository.SaveChangesAsync();
    }

    public async Task ChangeStatusAsync(int applicationId, int newStatusId)
    {
        var application = await _repository.GetByIdAsync(applicationId) ?? throw new NotFoundException($"Application with Id {applicationId} not found.");
        application.StatusId = newStatusId;

        await _repository.SaveChangesAsync();
    }

    public async Task ChangeHandlerAsync(int applicationId, int handlerId)
    {
        var application = await _repository.GetByIdAsync(applicationId) ?? throw new NotFoundException($"Application with Id {applicationId} not found.");
        application.HandlerId = handlerId;

        await _repository.SaveChangesAsync();
    }

    public async Task<List<Application>> GetApplicationsByUserIdAsync(int userId)
    {
        var userExists = await _repository.UserExistsAsync(userId);
        if (!userExists)
            throw new NotFoundException($"User with Id {userId} not found.");

        return await _repository.GetApplicationsByUserIdAsync(userId);
    }

    public async Task<Application?> GetFullApplicationDetailsAsync(int applicationId)
    {
        var application = await _repository.GetFullApplicationDetailsAsync(applicationId);
        
        return application ?? throw new NotFoundException($"Application with Id {applicationId} not found.");
    }
}
