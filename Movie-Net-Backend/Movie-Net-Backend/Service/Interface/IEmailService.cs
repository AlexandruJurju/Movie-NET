namespace Movie_Net_Backend.Service.Interface;

public interface IEmailService
{
    void Send(string to, string subject, string text);
}