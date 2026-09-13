using BusinessLogic.DTOs.JobOffer;

namespace BusinessLogic.Interfaces;

public interface IJobOfferService
{
    Task<int> CreateJobOfferAsync(JobOfferDto dto);
    Task UpdateJobOfferAsync(JobOfferDto dto);
}
