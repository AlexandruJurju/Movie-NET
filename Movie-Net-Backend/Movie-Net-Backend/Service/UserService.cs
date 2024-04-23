using FluentResults;
using Movie_Net_Backend.Data;
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

        if (user == null)
        {
            return Result.Fail<User>($"User with username {username} not found");
        }

        return user;
    }

    public Result<User> FindUserByEmail(string email)
    {
        var user = _appDbContext.Users.FirstOrDefault(u => u.Email == email);

        if (user == null)
        {
            return Result.Fail<User>($"User with email {email} not found");
        }

        return user;
    }

    public User SaveUser(User user)
    {
        _appDbContext.Users.Add(user);
        _appDbContext.SaveChanges();
        return user;
    }
}