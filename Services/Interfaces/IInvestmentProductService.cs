using ServiceXPinc.Models;
using ServiceXPinc.Models.RequestModel;
using ServiceXPinc.Models.ResponseModel;

namespace ServiceXPinc.Services.Interfaces
{
    public interface IInvestmentProductService
    {
        Task<List<InvestmentProductDetailsResponse>> ListInvestmentProductsAsync();
        Task<InvestmentProductDetailsResponse> GetInvestmentProductByIdAsync(Guid investmentProductId);
        Task<InvestmentProductDetailsResponse> CreateInvestmentProductAsync(InvestmentProductCreatedRequest investmentProduct);
        Task<InvestmentProductDetailsResponse> UpdateInvestmentProductAsync(InvestmentProductUpdatedRequest investmentProduct);
        void DeleteInvestmentProduct(Guid investmentProductId);
    }
}
