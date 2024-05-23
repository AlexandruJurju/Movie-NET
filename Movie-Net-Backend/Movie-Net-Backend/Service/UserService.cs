using FluentResults;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class UserService : IUserService
{
    private readonly AppDbContext _appDbContext;

    public UserService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
    }

    public Result<User> FindUserByUsername(string username)
    {
        var user = _appDbContext.Users.FirstOrDefault(u => u.Username == username);

        if (user == null) return Result.Fail<User>($"User with username {username} not found");

        return user;
    }

    public Result<User> FindUserByEmail(string email)
    {
        var user = _appDbContext.Users.FirstOrDefault(u => u.Email == email);

        if (user == null) return Result.Fail<User>($"User with email {email} not found");

        return user;
    }

    public Result<User> FindUserById(int userId)
    {
        var user = _appDbContext.Users.FirstOrDefault(u => u.Id == userId);

        if (user == null) return Result.Fail($"User with id {userId} not found");

        return user;
    }

    public Result DeleteUserById(int userId)
    {
        var userResult = FindUserById(userId);
        if (userResult.IsFailed) return userResult.ToResult();

        _appDbContext.Users.Remove(userResult.Value);
        _appDbContext.SaveChanges();
        return Result.Ok();
    }

    public User SaveUser(User user)
    {
        _appDbContext.Users.Add(user);
        _appDbContext.SaveChanges();
        return user;
    }

    public Result<User> UpdateUser(int userId, User user)
    {
        var userResult = FindUserById(userId);

        if (userResult.IsFailed) return userResult.ToResult();

        var existingUser = userResult.Value;

        existingUser.Username = user.Username ?? existingUser.Username;
        existingUser.Email = user.Email ?? existingUser.Email;
        existingUser.Password = user.Password ?? existingUser.Password;

        _appDbContext.SaveChanges();

        return existingUser;
    }

    public IEnumerable<User> FindAllUsers()
    {
        return _appDbContext.Users.ToList();
    }
}