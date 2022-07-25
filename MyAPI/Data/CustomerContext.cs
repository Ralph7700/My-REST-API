using Microsoft.EntityFrameworkCore;
using MyAPI.Models;

namespace MyAPI.Data{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
            
        }
        public DbSet<Customer> customers { get; set; }
    }
}