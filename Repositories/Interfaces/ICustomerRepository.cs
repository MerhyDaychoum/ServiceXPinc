using ServiceXPinc.Models;

namespace ServiceXPinc.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> ListCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(Guid customerId);
        Task<Customer> CreateCustomerAsync(Customer customer);
        void UpdateCustomerAsync(Customer customer);
    }
}
