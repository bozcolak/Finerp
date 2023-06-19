using Finerp_web.Data.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Finerp_web.Controllers;

public class CustomerController : Controller
{
    private readonly CustomerRepository _customerRepository;

    public CustomerController(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public IActionResult Index()
    {
        var customers = _customerRepository.GetAllCustomers();
        return View(customers);
    }
}
