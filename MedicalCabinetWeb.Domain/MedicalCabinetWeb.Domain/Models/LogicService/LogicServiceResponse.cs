using System.Net;

namespace MedicalCabinetWeb.Domain.Models.LogicService;

public class LogicServiceResponse
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    
    public static LogicServiceResponse NotFound(string? message = null) => new()
    {
        IsSuccess = false,
        Message = message,
        StatusCode = HttpStatusCode.NotFound  
    };
    
}