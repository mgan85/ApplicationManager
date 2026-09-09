namespace BusinessLogic.DTOs.Application;

public class ApplicationDto
{
    public int Id { get; set; }
    public bool IsApplied { get; set; }
    public DateTime? ApplyDate { get; set; }
    public string StatusName { get; set; } = string.Empty;

    public int? JobOfferId { get; set; }
    public string? JobOfferTitle { get; set; }

    public int? UserId { get; set; }
    public string? UserName { get; set; }

    public int? HandlerId { get; set; }
    public string? HandlerName { get; set; }
}
