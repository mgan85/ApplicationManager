namespace BusinessLogic.DTOs.Handler;

public class CreateHandlerDto
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int PhoneId { get; set; }
}
