using BusinessLogic.DTOs.Application;

namespace BusinessLogic.Interfaces;

public interface IApplicationService
{
    Task<int> CreateApplicationAsync(CreateApplicationDto dto);
    Task SubmitApplicationAsync(int applicationId);
    Task ChangeStatusAsync(int applicationId, int newStatusId);
}
