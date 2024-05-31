using FluentResults;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IUserService
{
    Task<Result<User>> FindUserByUsernameAsync(string username);
    Task<Result<User>> FindUserByEmailAsync(string email);
    Task<Result<User>> FindUserByIdAsync(int userId);
    Task<Result> DeleteUserByIdAsync(int userId);
    Task<User> SaveUserAsync(User user);
    Task<Result<User>> UpdateUserAsync(int userId, User userDto);
    Task<IEnumerable<User>> FindAllUsersAsync();
}