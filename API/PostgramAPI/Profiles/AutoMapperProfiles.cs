using AutoMapper;
using PostgramAPI.DTOs;
using PostgramAPI.Models;

namespace PostgramAPI.Profiles;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Post, PostDto>();
        CreateMap<PostDto, Post>();

        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();

        CreateMap<UsersDto, User>();
        CreateMap<User, UsersDto>();

        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>();

        CreateMap<User, UpdateUserRequest>();
        CreateMap<UpdateUserRequest, User>();

        CreateMap<CreatePostRequest, Post>();
    }
}