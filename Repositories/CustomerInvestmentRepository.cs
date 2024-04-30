using Microsoft.EntityFrameworkCore;
using ServiceXPinc.DatabaseContext;
using ServiceXPinc.Models;
using ServiceXPinc.Repositories.Interfaces;

namespace ServiceXPinc.Repositories
{
    public class CustomerInvestmentRepository : ICustomerInvestmentRepository
    {
        private readonly XPDatabaseContext _dbContext;
        public CustomerInvestmentRepository(XPDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CustomerInvestment>> ListCustomerInvestmentAsync()
        {
            return await _dbContext.CustomerInvestments.ToListAsync();
        }

        public async Task<CustomerInvestment> GetCustomerInvestmentByIdAsync(Guid customerInvestmentId)
        {
            return await _dbContext.CustomerInvestments.FindAsync(customerInvestmentId);
        }

        public async Task<List<CustomerInvestment>> GetCustomerInvestmentByCustomerIdAsync(Guid customerId)
        {
            return await _dbContext.CustomerInvestments.Where(a => a.CustomerId == customerId).ToListAsync();
        }

        public async Task<CustomerInvestment> CreateCustomerInvestment(CustomerInvestment customerInvestment)
        {
            customerInvestment.Id = Guid.NewGuid();
            customerInvestment.CreatedDate = DateTime.Now;

            await _dbContext.CustomerInvestments.AddAsync(customerInvestment);
            await _dbContext.SaveChangesAsync();
            return customerInvestment;
        }

        public async void DeleteCustomerInvestment(CustomerInvestment customerInvestment)
        {
            _dbContext.CustomerInvestments.Remove(customerInvestment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
