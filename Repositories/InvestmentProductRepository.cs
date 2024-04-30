using Microsoft.EntityFrameworkCore;
using ServiceXPinc.DatabaseContext;
using ServiceXPinc.Models;
using ServiceXPinc.Repositories.Interfaces;

namespace ServiceXPinc.Repositories
{
    public class InvestmentProductRepository : IInvestmentProductRepository
    {
        private readonly XPDatabaseContext _dbContext;
        public InvestmentProductRepository(XPDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<InvestmentProduct>> ListInvestmentProductsAsync()
        {
            return await _dbContext.InvestmentProducts.ToListAsync();
        }

        public async Task<InvestmentProduct> GetInvestmentProductByIdAsync(Guid investmentId)
        {
            return await _dbContext.InvestmentProducts.FindAsync(investmentId);
        }

        public async Task<InvestmentProduct> CreateInvestmentProductAsync(InvestmentProduct investmentProduct)
        {
            investmentProduct.Id = Guid.NewGuid();
            investmentProduct.DueDate = DateTime.Now.AddDays(30);

            await _dbContext.InvestmentProducts.AddAsync(investmentProduct);
            await _dbContext.SaveChangesAsync();

            return investmentProduct;
        }

        public async Task<InvestmentProduct> UpdateInvestmentProductAsync(InvestmentProduct investmentProduct)
        {
            _dbContext.InvestmentProducts.Update(investmentProduct);
            await _dbContext.SaveChangesAsync();
            return investmentProduct;
        }

        public void DeleteInvestmentProduct(InvestmentProduct investmentProduct)
        {
            _dbContext.InvestmentProducts.Remove(investmentProduct);
            _dbContext.SaveChanges();
        }
    }
}
