using PostgramAPI.DTOs;

namespace PostgramAPI.Services;

public interface IUserService
{
    Task<List<UsersDto>> GetAllUsers();
    Task<UserDto> GetUserById(int id);

    Task<UserDto> UpdateUserDetails(UpdateUserRequest request, int userId);
}