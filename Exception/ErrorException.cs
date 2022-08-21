namespace publication.exceptions;

public class ErrorException : Exception
{
    private readonly int _statusCode;
    public int StatusCode { get => _statusCode; }
    public ErrorException(int statusCode, string message) : base(message)
    {
        _statusCode = statusCode;
    }
}