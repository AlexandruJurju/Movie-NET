namespace Movie_Net_Backend.Helper;

public class SmtpSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public string EmailFrom { get; set; }
}