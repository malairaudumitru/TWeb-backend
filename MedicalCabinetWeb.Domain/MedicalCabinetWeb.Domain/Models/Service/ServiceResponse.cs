namespace MedicalCabinetWeb.Domain.Models.Service;

public class ServiceResponse
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
    public int StatusCode { get; set; }
    //HttpStatusCode 404 
    
    public static ServiceResponse Ok(string message) => new ServiceResponse { IsSuccess = true, Message = message };
    public static ServiceResponse BadRequest(string message) => new ServiceResponse { IsSuccess = false, Message = message };
}