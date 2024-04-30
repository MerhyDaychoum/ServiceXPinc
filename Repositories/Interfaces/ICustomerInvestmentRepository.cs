using ServiceXPinc.Models;

namespace ServiceXPinc.Repositories.Interfaces
{
    public interface ICustomerInvestmentRepository
    {
        Task<List<CustomerInvestment>> ListCustomerInvestmentAsync();
        Task<CustomerInvestment> GetCustomerInvestmentByIdAsync(Guid customerInvestmentId);
        Task<List<CustomerInvestment>> GetCustomerInvestmentByCustomerIdAsync(Guid customerId);
        Task<CustomerInvestment> CreateCustomerInvestment(CustomerInvestment customerInvestment);
        void DeleteCustomerInvestment(CustomerInvestment customerInvestment);
    }
}
