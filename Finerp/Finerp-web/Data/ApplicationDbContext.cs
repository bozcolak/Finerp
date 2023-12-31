﻿using Finerp_web.Data.Customers;
using Finerp_web.Data.Inventories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Finerp_web.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}