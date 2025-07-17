namespace PostgramAPI.DTOs;

public class CreateUserRequest
{
    public string DisplayName { get; set; }
    public string Bio { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}