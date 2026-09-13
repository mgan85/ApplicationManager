using BusinessLogic.DTOs.Address;

namespace BusinessLogic.Interfaces;

public interface IAddressService
{
    Task<int> CreateAddressAsync(AddressDto dto);
    Task<int> UpdateAddressAsync(AddressDto dto);
    Task<AddressDto> GetAddressByIdAsync(int id);
}