using ServiceXPinc.Models;
using ServiceXPinc.Models.RequestModel;
using ServiceXPinc.Models.ResponseModel;
using ServiceXPinc.Repositories;
using ServiceXPinc.Repositories.Interfaces;
using ServiceXPinc.Services.Interfaces;

namespace ServiceXPinc.Services
{
    public class CustomerInvestmentService : ICustomerInvestmentService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerInvestmentRepository _customerInvestmentRepository;
        private readonly IInvestmentProductRepository _investmentProductRepository;
        public CustomerInvestmentService(ICustomerInvestmentRepository customerInvestmentRepository, ICustomerRepository customerRepository, IInvestmentProductRepository investmentProductRepository)
        {
            _customerInvestmentRepository = customerInvestmentRepository;
            _customerRepository = customerRepository;
            _investmentProductRepository = investmentProductRepository;
        }

        public async Task<List<CustomerInvestmentDetailsResponse>> ListCustomerInvestmentAsync()
        {
            var result = await _customerInvestmentRepository.ListCustomerInvestmentAsync();
            return result.Select(a => new CustomerInvestmentDetailsResponse(a)).ToList();
        }

        public async Task<CustomerInvestmentExtractResponse> GetCustomerInvestmentByCustomerIdAsync(Guid customerId)
        {
            var result = await _customerInvestmentRepository.GetCustomerInvestmentByCustomerIdAsync(customerId);
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);

            var customerInvestmentExtractResult = new CustomerInvestmentExtractResponse(customer.Id, customer.Name, customer.Email, new List<InvestmentProductDetailsResponse>() { });
            foreach (var item in result)
            {
                var investmentProduct = await _investmentProductRepository.GetInvestmentProductByIdAsync(item.InvestmentId);
                customerInvestmentExtractResult.InvestmentProducts.Add(new InvestmentProductDetailsResponse(investmentProduct));
            }
            return customerInvestmentExtractResult;
        }

        public async Task<CustomerInvestmentDetailsResponse> BuyInvestmentAsync(CustomerInvestmentCreatedRequest request)
        {
            var createdCustomerinvestment = await _customerInvestmentRepository.CreateCustomerInvestment(new CustomerInvestment(request.CustomerId, request.InvestmentId));

            if (createdCustomerinvestment != null)
            {
                var customer = await _customerRepository.GetCustomerByIdAsync(createdCustomerinvestment.CustomerId);

                var currentinvestment = await _investmentProductRepository.GetInvestmentProductByIdAsync(createdCustomerinvestment.InvestmentId);

                customer.BallanceInWallet = customer.BallanceInWallet - currentinvestment.CurrentValue;
                _customerRepository.UpdateCustomerAsync(customer);
            }

            return new CustomerInvestmentDetailsResponse(createdCustomerinvestment);
        }

        public async void SellInvestmentAsync(Guid customerInvestmentId)
        {
            var customerInvestment = await _customerInvestmentRepository.GetCustomerInvestmentByIdAsync(customerInvestmentId);

            _customerInvestmentRepository.DeleteCustomerInvestment(customerInvestment);

            var customer = await _customerRepository.GetCustomerByIdAsync(customerInvestment.CustomerId);

            var currentinvestment = await _investmentProductRepository.GetInvestmentProductByIdAsync(customerInvestment.InvestmentId);

            customer.BallanceInWallet = customer.BallanceInWallet + currentinvestment.CurrentValue;
            _customerRepository.UpdateCustomerAsync(customer);
        }
    }
}
