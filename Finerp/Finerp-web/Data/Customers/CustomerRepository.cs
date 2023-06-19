namespace Finerp_web.Data.Customers;

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Customer> GetAllCustomers()
    {
        return _context.Customers.ToList();
    }

    public Customer GetCustomerById(int customerId)
    {
        return _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
    }

    public void AddCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }

    public void UpdateCustomer(Customer customer)
    {
        _context.Entry(customer).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteCustomer(int customerId)
    {
        var customer = _context.Customers.Find(customerId);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
