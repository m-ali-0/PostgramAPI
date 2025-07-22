using PostgramAPI.DTOs;
using PostgramAPI.Models;

namespace PostgramAPI.Services;

public interface IAuthService
{
    Task<string> Login(LoginDto login);
    Task<Auth> Create(CreateAuthRequest request);
}