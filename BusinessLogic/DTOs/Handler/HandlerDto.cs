using BusinessLogic.DTOs.Phone;

namespace BusinessLogic.DTOs.Handler;

public class HandlerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public PhoneDto Phone { get; set; } = default!;
}