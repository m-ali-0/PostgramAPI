using PostgramAPI.DTOs;

namespace PostgramAPI.Services;

public interface IAuthService
{
    Task<string> Login(LoginDto login);
    Task<AuthDto> Create(CreateAuthRequest request);
}