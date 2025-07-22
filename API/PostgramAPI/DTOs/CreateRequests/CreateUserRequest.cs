namespace PostgramAPI.DTOs;

public class CreateUserRequest
{
    public string? DisplayName { get; set; }
    public string? Bio { get; set; }
    public string? ProfilePic { get; set; }
    public int? Age { get; set; }

}