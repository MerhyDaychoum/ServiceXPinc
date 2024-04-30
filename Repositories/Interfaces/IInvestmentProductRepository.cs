using ServiceXPinc.Models;

namespace ServiceXPinc.Repositories.Interfaces
{
    public interface IInvestmentProductRepository
    {
        Task<List<InvestmentProduct>> ListInvestmentProductsAsync();
        Task<InvestmentProduct> GetInvestmentProductByIdAsync(Guid investmentId);
        Task<InvestmentProduct> CreateInvestmentProductAsync(InvestmentProduct investmentProduct);
        Task<InvestmentProduct> UpdateInvestmentProductAsync(InvestmentProduct investmentProduct);
        void DeleteInvestmentProduct(InvestmentProduct investmentProduct);
    }
}
