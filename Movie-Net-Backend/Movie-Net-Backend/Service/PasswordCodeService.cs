using FluentResults;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class PasswordCodeService(IEmailService emailService, IUserService userService, AppDbContext appDbContext) : IPasswordCodeService
{
    public async Task<Result<User>> ForgotPasswordRequestAsync(ForgotPasswordDto forgotPasswordDto)
    {
        var userResult = await userService.FindUserByEmailAsync(forgotPasswordDto.Email);

        if (userResult.IsFailed) return userResult.ToResult();

        string code = GenerateResetCode(16);
        SendResetRequestEmailAsync(forgotPasswordDto, code);
        await SaveCodeAsync(userResult.Value, code);

        return Result.Ok(userResult.Value);
    }

    public async Task DeleteCodeAsync(User user)
    {
        var codeResult = appDbContext.PasswordCodes.FirstOrDefault(pc => pc.UserId == user.Id);
        appDbContext.PasswordCodes.Remove(codeResult);
        await appDbContext.SaveChangesAsync();
    }

    public Result<bool> CodesMatch(User user, string code)
    {
        var passwordCode = appDbContext.PasswordCodes.FirstOrDefault(pc => pc.UserId == user.Id);
        if (passwordCode == null) return Result.Fail($"User {user.Id} has no codes");

        if (code != passwordCode.Code) return Result.Fail("Codes don't match");

        return Result.Ok(true);
    }

    private async Task SaveCodeAsync(User user, string code)
    {
        var existingCode = appDbContext.PasswordCodes.FirstOrDefault(pc => pc.UserId == user.Id);
        if (existingCode != null)
        {
            existingCode.Code = code;
            await appDbContext.SaveChangesAsync();
        }
        else
        {
            PasswordCode passwordCode = new PasswordCode
            {
                Code = code,
                User = user
            };

            await appDbContext.PasswordCodes.AddAsync(passwordCode);
            await appDbContext.SaveChangesAsync();
        }
    }

    private void SendResetRequestEmailAsync(ForgotPasswordDto forgotPasswordDto, string code)
    {
        string message = "Please enter this code to reset your password: \n" + code;
        emailService.Send(forgotPasswordDto.Email, "Password Reset", message);
    }

    private string GenerateResetCode(int length)
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}