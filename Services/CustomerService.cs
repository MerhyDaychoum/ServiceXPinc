using ServiceXPinc.Models;
using ServiceXPinc.Models.RequestModel;
using ServiceXPinc.Models.ResponseModel;
using ServiceXPinc.Repositories.Interfaces;
using ServiceXPinc.Services.Interfaces;

namespace ServiceXPinc.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerDetailsResponse>> ListCustomersAsync()
        {
            var result = await _customerRepository.ListCustomersAsync();
            return result.Select(a => new CustomerDetailsResponse(a)).ToList();
        }

        public async Task<CustomerDetailsResponse> GetCustomerByIdAsync(Guid customerId)
        {
            return new CustomerDetailsResponse(await _customerRepository.GetCustomerByIdAsync(customerId));
        }

        public async Task<CustomerDetailsResponse> CreateCustomerAsync(CustomerCreatedRequest request)
        {
            var createdCustomer = await _customerRepository.CreateCustomerAsync(new Customer(request.Name, request.Email, request.BallanceInWallet));
            return new CustomerDetailsResponse(await _customerRepository.GetCustomerByIdAsync(createdCustomer.Id));
        }
    }
}
