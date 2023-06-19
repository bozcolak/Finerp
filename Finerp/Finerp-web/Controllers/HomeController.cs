using System.Diagnostics;
using Finerp_web.Data.Customers;
using Microsoft.AspNetCore.Mvc;
using Finerp_web.Models;

namespace Finerp_web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CustomerRepository _customerRepository;

    public HomeController(ILogger<HomeController> logger,CustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }

    public IActionResult Index()
    {
     
        return View();
     
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}