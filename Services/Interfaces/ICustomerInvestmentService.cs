using ServiceXPinc.Models;
using ServiceXPinc.Models.RequestModel;
using ServiceXPinc.Models.ResponseModel;

namespace ServiceXPinc.Services.Interfaces
{
    public interface ICustomerInvestmentService
    {
        Task<List<CustomerInvestmentDetailsResponse>> ListCustomerInvestmentAsync();
        Task<CustomerInvestmentExtractResponse> GetCustomerInvestmentByCustomerIdAsync(Guid customerId);
        Task<CustomerInvestmentDetailsResponse> BuyInvestmentAsync(CustomerInvestmentCreatedRequest request);
        void SellInvestmentAsync(Guid customerInvestmentId);
    }
}
