using PostgramAPI.DTOs;
using PostgramAPI.Models;

namespace PostgramAPI.Services;

public interface IUserService
{
    Task<User> PostUser(CreateUserRequest request);
    Task<List<UsersDto>> GetAllUsers();
    Task<UserDto> GetUserById(int id);
    
    Task<User> UpdateUserDetails(CreateUserRequest request, int  userId);

}