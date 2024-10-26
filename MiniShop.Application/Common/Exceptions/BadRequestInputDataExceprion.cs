namespace MiniShop.Application.Common.Exceptions;

public class BadRequestInputDataException : Exception
{
    public string ErrorMessage { get; set; }
    
    public BadRequestInputDataException(string message) : base(message)
    {
        ErrorMessage = message;
    }
}