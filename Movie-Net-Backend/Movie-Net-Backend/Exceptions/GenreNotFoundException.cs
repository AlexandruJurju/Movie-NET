namespace Movie_Net_Backend.Exceptions;

public class GenreNotFoundException : Exception
{
    public GenreNotFoundException() : base()
    {
    }

    public GenreNotFoundException(string message) : base(message)
    {
    }

    public GenreNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}