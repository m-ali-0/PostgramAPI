using PostgramAPI.DTOs;

namespace PostgramAPI.Services;

public interface IAuthServices
{
    Task<string> Login(LoginDto login);
}