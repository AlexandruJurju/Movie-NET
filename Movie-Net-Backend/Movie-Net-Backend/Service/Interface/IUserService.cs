using FluentResults;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IUserService
{
    Result<User> FindUserByUsername(string username);
    Result<User> FindUserByEmail(string email);
    Result<User> FindUserById(int userId);
    Result DeleteUserById(int userId);
    User SaveUser(User user);
    Result<User> UpdateUser(int userId, User userDto);
    IEnumerable<User> FindAllUsers();
}