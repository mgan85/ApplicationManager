using BusinessLogic.DTOs.Application;
using BusinessLogic.Exceptions;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using DataLogic;
using DataLogic.Entities;

namespace BusinessLogic.Services;

//consider repository pattern for better separation of concerns and testability.
public class ApplicationService(ApplicationDbContext context) : IApplicationService
{
    private readonly ApplicationDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    public async Task<int> CreateApplicationAsync(CreateApplicationDto dto)
    {
        var userExists = await _context.Users.AnyAsync(u => u.Id == dto.UserId);
        if (!userExists)
            throw new NotFoundException($"Użytkownik o Id {dto.UserId} nie istnieje.");

        var offerExists = await _context.JobOffers.AnyAsync(j => j.Id == dto.JobOfferId);
        if (!offerExists)
            throw new NotFoundException($"Oferta pracy o Id {dto.JobOfferId} nie istnieje.");

        var entity = new Application
        {
            UserId = dto.UserId,
            JobOfferId = dto.JobOfferId,
            HandlerId = dto.HandlerId,

            // IsApplied is computed from ApplyDate; leave ApplyDate null for DRAFT
            StatusId = 1 // Status: DRAFT
        };

        _context.Applications.Add(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task SubmitApplicationAsync(int applicationId)
    {
        var application = await _context.Applications.FindAsync(applicationId);
        if (application == null)
            throw new NotFoundException($"Application with Id {applicationId} not found.");

        application.ApplyDate = DateTime.UtcNow;
        application.StatusId = 2;

        await _context.SaveChangesAsync();
    }

    public async Task ChangeStatusAsync(int applicationId, int newStatusId)
    {
        var application = await _context.Applications.FindAsync(applicationId) ?? throw new NotFoundException($"Application with Id {applicationId} not found.");
        application.StatusId = newStatusId;
        await _context.SaveChangesAsync();
    }
}
