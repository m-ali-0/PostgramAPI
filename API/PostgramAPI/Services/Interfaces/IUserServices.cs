using PostgramAPI.DTOs;
using PostgramAPI.Models;

namespace PostgramAPI.Services;

public interface IUserServices
{
    Task<User> PostUser(CreateUserRequest request);
    Task<List<UsersDto>> GetUsers();
    Task<UserDto> GetUser(int id);

}