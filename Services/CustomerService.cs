using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using ConsoleApp.Models.Responses;
using Newtonsoft.Json;
using System.Diagnostics;
namespace ConsoleApp.Services;

public class CustomerService
{
    private readonly FileService fileService = new FileService();
    private List<Customer> _customers = [];

    // Den här delen är skapad för att kunna lägga till en ny andvändare till en text fil med hjälp av JSON.
    public ServiceResult AddCustomerToList(Customer customer)
    {
        ServiceResult response = new ServiceResult();

        try
        {
            if (!_customers.Any(x => x.Email == customer.Email))
            {
                _customers.Add(customer);

                var json = JsonConvert.SerializeObject(_customers);

                fileService.SaveConentToFile(json);
                response.Status = Enums.ServiceStatus.SUCCESSED;
            }
            else
            {
                response.Status = Enums.ServiceStatus.ALREADY_EXISTS;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.Status = Enums.ServiceStatus.FAILED;
            response.Result = ex.Message;
        }

        return response;
    }

    // Här så hämtas en specifik kund från text filen.
    public IEnumerable<Customer> GetCustomerFromList()
    {
        ServiceResult response = new ServiceResult();

        try
        {
            var content = fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _customers = JsonConvert.DeserializeObject<List<Customer>>(content)!;
            }

            
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }

    // Och här hämtas alla kunder från text filen.
    public IEnumerable<Customer> GetAllFromList()
    {
        try
        {
            var content = fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _customers = JsonConvert.DeserializeObject<List<Customer>>(content)!;
            }

            return _customers;
        }

        catch (Exception ex) {Debug.WriteLine(ex.Message); }
        return null!;
    }
}
