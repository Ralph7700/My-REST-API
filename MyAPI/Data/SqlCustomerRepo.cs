using MyAPI.Models;

namespace MyAPI.Data{
    public class SqlCustomerRepo : ICustomerRepo
    {
        private readonly CustomerContext _context;

        public SqlCustomerRepo(CustomerContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
           return _context.customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.customers.FirstOrDefault(p => p.ID == id);
            
        }
        public void CreateCustomer(Customer customer)
        {
            if(customer == null) throw new ArgumentNullException(nameof(customer));
            
            _context.customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            
        }

        public void DeleteCustomer(Customer customer){
            if(customer == null){
                throw new ArgumentNullException(nameof(customer));
            }
            _context.customers.Remove(customer);
        }

        public bool SaveChages()
        { 
            return (_context.SaveChanges() >=0); 
        }
    }
}