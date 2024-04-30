using Microsoft.EntityFrameworkCore;
using ServiceXPinc.DatabaseContext;
using ServiceXPinc.Models;
using ServiceXPinc.Repositories.Interfaces;

namespace ServiceXPinc.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly XPDatabaseContext _dbContext;

        public CustomerRepository(XPDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Customer>> ListCustomersAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid customerId)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            customer.RegistrationDate = DateTime.Now;

            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return customer;
        }

        public async void UpdateCustomerAsync(Customer customer)
        {
            _dbContext.Update(customer);
            await _dbContext.SaveChangesAsync();
        }
    }
}
