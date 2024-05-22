using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Movie_Net_Backend.Helper;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;

    public EmailService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }


    public void Send(string to, string subject, string text)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_smtpSettings.EmailFrom));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Plain) { Text = text };

        using var smtp = new SmtpClient();
        smtp.Connect(_smtpSettings.Host, _smtpSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_smtpSettings.User, _smtpSettings.Password);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}