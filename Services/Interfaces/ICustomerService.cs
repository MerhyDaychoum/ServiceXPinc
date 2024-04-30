using ServiceXPinc.Models;
using ServiceXPinc.Models.RequestModel;
using ServiceXPinc.Models.ResponseModel;

namespace ServiceXPinc.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDetailsResponse>> ListCustomersAsync();
        Task<CustomerDetailsResponse> GetCustomerByIdAsync(Guid customerId);
        Task<CustomerDetailsResponse> CreateCustomerAsync(CustomerCreatedRequest request);
    }
}
