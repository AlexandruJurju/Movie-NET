using FluentResults;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class PasswordCodeService : IPasswordCodeService
{
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;
    private readonly AppDbContext _appDbContext;

    public PasswordCodeService(IEmailService emailService, IUserService userService, AppDbContext appDbContext)
    {
        _emailService = emailService;
        _userService = userService;
        _appDbContext = appDbContext;
    }

    public Result<User> ForgotPasswordRequest(ForgotPasswordDto forgotPasswordDto)
    {
        var userResult = _userService.FindUserByEmail(forgotPasswordDto.Email);

        if (userResult.IsFailed) return userResult.ToResult();

        string code = GenerateResetCode(16);
        SendResetRequestEmail(forgotPasswordDto, code);
        SaveCode(userResult.Value, code);

        return Result.Ok(userResult.Value);
    }

    public void DeleteCode(User user)
    {
        var codeResult = _appDbContext.PasswordCodes.FirstOrDefault(pc => pc.UserId == user.Id);
        _appDbContext.PasswordCodes.Remove(codeResult);
        _appDbContext.SaveChanges();
    }

    public Result<bool> CodesMatch(User user, string code)
    {
        var passwordCode = _appDbContext.PasswordCodes.FirstOrDefault(pc => pc.UserId == user.Id);
        if (passwordCode == null) return Result.Fail($"User {user.Id} has no codes");

        if (code != passwordCode.Code) return Result.Fail("Codes don't match");

        return true;
    }

    private void SaveCode(User user, string code)
    {
        var existingCode = _appDbContext.PasswordCodes.FirstOrDefault(pc => pc.UserId == user.Id);
        if (existingCode != null)
        {
            existingCode.Code = code;
            _appDbContext.SaveChanges();
        }
        else
        {
            PasswordCode passwordCode = new PasswordCode
            {
                Code = code,
                User = user
            };

            _appDbContext.PasswordCodes.Add(passwordCode);
            _appDbContext.SaveChanges();
        }
    }

    private void SendResetRequestEmail(ForgotPasswordDto forgotPasswordDto, string code)
    {
        string message = "Please enter this code to reset your password: \n" + code;
        _emailService.Send(forgotPasswordDto.Email, "Password Reset", message);
    }

    private string GenerateResetCode(int length)
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}