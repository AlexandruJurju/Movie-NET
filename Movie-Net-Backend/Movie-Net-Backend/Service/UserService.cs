using FluentResults;
using Microsoft.EntityFrameworkCore;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class UserService(AppDbContext appDbContext) : IUserService
{
    private readonly AppDbContext _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));

    public async Task<Result<User>> FindUserByUsernameAsync(string username)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

        if (user == null) return Result.Fail<User>($"User with username {username} not found");

        return user;
    }

    public async Task<Result<User>> FindUserByEmailAsync(string email)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (user == null) return Result.Fail<User>($"User with email {email} not found");

        return user;
    }

    public async Task<Result<User>> FindUserByIdAsync(int userId)
    {
        var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null) return Result.Fail($"User with id {userId} not found");

        return user;
    }

    public async Task<Result> DeleteUserByIdAsync(int userId)
    {
        var userResult = await FindUserByIdAsync(userId);
        if (userResult.IsFailed) return userResult.ToResult();

        _appDbContext.Users.Remove(userResult.Value);
        await _appDbContext.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<User> SaveUserAsync(User user)
    {
        await _appDbContext.Users.AddAsync(user);
        await _appDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<Result<User>> UpdateUserAsync(int userId, User user)
    {
        var userResult = await FindUserByIdAsync(userId);

        if (userResult.IsFailed) return userResult.ToResult();

        var existingUser = userResult.Value;

        existingUser.Username = user.Username ?? existingUser.Username;
        existingUser.Email = user.Email ?? existingUser.Email;
        existingUser.Password = user.Password ?? existingUser.Password;

        await _appDbContext.SaveChangesAsync();

        return existingUser;
    }

    public async Task<IEnumerable<User>> FindAllUsersAsync()
    {
        return await _appDbContext.Users.ToListAsync();
    }
}