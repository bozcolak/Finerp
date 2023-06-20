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

    public IActionResult Detail(int customerId)
    {
        Customer customer = new Customer();
        if (customerId != 0)
            customer = _customerRepository.GetCustomerById(customerId);
        return View(customer);
    }

    [HttpPost]
    public IActionResult Detail(Customer customer)
    {
        if (customer.CustomerId == 0)
        {
            _customerRepository.AddCustomer(customer);
        }
        else
        {
            _customerRepository.UpdateCustomer(customer);
        }


        return
            RedirectToAction(
                "Index"); // İşlem tamamlandıktan sonra yönlendirme yapılabilir, örneğin Index sayfasına yönlendirme yapılıyor.
    }

    [HttpPost]
    public IActionResult Delete(Customer customer)
    {
        _customerRepository.DeleteCustomer(customer.CustomerId);


        return
            RedirectToAction(
                "Index"); // İşlem tamamlandıktan sonra yönlendirme yapılabilir, örneğin Index sayfasına yönlendirme yapılıyor.
    }
}