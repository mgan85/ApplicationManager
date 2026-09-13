using BusinessLogic.DTOs.Handler;

namespace BusinessLogic.Interfaces;

public interface IHandlerService
{
    Task<int> CreateHandleAsync(HandlerDto dto);
    Task UpdateHandleAsync(HandlerDto dto);
    Task DeleteHandlerAsync(int id);
}
