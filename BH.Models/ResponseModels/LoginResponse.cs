namespace BH.Models.ResponseModels;

public class LoginResponse
{
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? OrganizationId { get; set; }
    public string? Token { get; set; }
}