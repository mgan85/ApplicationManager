using BusinessLogic.DTOs.Phone;

namespace BusinessLogic.Interfaces;

public interface IPhoneService
{
    Task<int> CreatePhoneAsync(PhoneDto dto);
    Task UpdatePhoneAsync(PhoneDto dto);
}
