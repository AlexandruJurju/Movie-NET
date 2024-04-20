namespace Movie_Net_Backend.Exceptions;

public class MovieNotFoundException : Exception
{
    public MovieNotFoundException() : base()
    {
    }

    public MovieNotFoundException(string message) : base(message)
    {
    }

    public MovieNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}