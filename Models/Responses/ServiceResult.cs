namespace ConsoleApp.Models.Responses;

using ConsoleApp.Enums;
using ConsoleApp.Interfaces;
using ConsoleApp.Models;

public class ServiceResult
{
    public ServiceStatus Status { get; set; }
    public object Result { get; set; } = null!;

    //public string FirstName { get; set; } = null!;

    //public string LastName { get; set; } = null!;

    //public string Email { get; set; } = null!;
    //public string StreetName { get; set; } = null!;
    //public string PostalCode { get; set; } = null!;
    //public string City { get; set; } = null!;
}