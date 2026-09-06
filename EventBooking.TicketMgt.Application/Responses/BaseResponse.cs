namespace EventBooking.TicketMgt.Application.Responses;

/// <summary>
/// Can be used by commands to return a response to consumers
/// </summary>
public class BaseResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string>? ValidationErrors { get; set; }

    public BaseResponse()
    {
        Success = true;
    }
    public BaseResponse(string message)
    { 
        Success = true;
        Message = message;
    }
    public BaseResponse(string message, bool success)
    {
        Success = true;
        Message = message;
    }
}
