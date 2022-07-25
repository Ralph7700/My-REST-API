using MyAPI.Models;

namespace MyAPI.Data{
    public interface ICustomerRepo{
    
    bool SaveChages();
    
    IEnumerable<Customer> GetAllCustomers();
    
    Customer GetCustomerById(int id);

    void CreateCustomer(Customer customer);

    void UpdateCustomer(Customer customer);

    void DeleteCustomer(Customer customer);
    }
}