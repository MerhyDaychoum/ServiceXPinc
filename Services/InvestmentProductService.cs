using Microsoft.EntityFrameworkCore;
using ServiceXPinc.Models;
using ServiceXPinc.Models.RequestModel;
using ServiceXPinc.Models.ResponseModel;
using ServiceXPinc.Repositories.Interfaces;
using ServiceXPinc.Services.Interfaces;

namespace ServiceXPinc.Services
{
    public class InvestmentProductService : IInvestmentProductService
    {
        private readonly IInvestmentProductRepository _investmentProductRepository;
        public InvestmentProductService(IInvestmentProductRepository investmentProductRepository)
        {
            _investmentProductRepository = investmentProductRepository;
        }

        public async Task<List<InvestmentProductDetailsResponse>> ListInvestmentProductsAsync()
        {
            var result = await _investmentProductRepository.ListInvestmentProductsAsync();
            return result.Select(a => new InvestmentProductDetailsResponse(a)).ToList();
        }

        public async Task<InvestmentProductDetailsResponse> GetInvestmentProductByIdAsync(Guid investmentProductId)
        {
            return new InvestmentProductDetailsResponse(await _investmentProductRepository.GetInvestmentProductByIdAsync(investmentProductId));
        }

        public async Task<InvestmentProductDetailsResponse> CreateInvestmentProductAsync(InvestmentProductCreatedRequest request)
        {
            var createdInvestmentProduct = await _investmentProductRepository.CreateInvestmentProductAsync(new InvestmentProduct(request.Name, request.Type, request.InitialInvestment, request.CurrentValue,
                                                                                                                                                request.AnnualReturnValue, request.RiskLevel));
            return new InvestmentProductDetailsResponse(await _investmentProductRepository.GetInvestmentProductByIdAsync(createdInvestmentProduct.Id));
        }

        public async Task<InvestmentProductDetailsResponse> UpdateInvestmentProductAsync(InvestmentProductUpdatedRequest request)
        {
            var currentInvestmentProduct = await _investmentProductRepository.GetInvestmentProductByIdAsync(request.Id);

            currentInvestmentProduct.AnnualReturnValue = request.AnnualReturnValue;
            currentInvestmentProduct.CurrentValue = request.CurrentValue;
            currentInvestmentProduct.RiskLevel = request.RiskLevel;
            currentInvestmentProduct.Name = request.Name;
            currentInvestmentProduct.Type = request.Type;
            currentInvestmentProduct.InitialInvestment = request.InitialInvestment;
            currentInvestmentProduct.DueDate = request.DueDate;

            await _investmentProductRepository.UpdateInvestmentProductAsync(currentInvestmentProduct);
            return new InvestmentProductDetailsResponse(currentInvestmentProduct);
        }

        public async void DeleteInvestmentProduct(Guid investmentProductId)
        {
            var currentInvestmentProduct = await _investmentProductRepository.GetInvestmentProductByIdAsync(investmentProductId);
            _investmentProductRepository.DeleteInvestmentProduct(currentInvestmentProduct);
        }
    }
}
