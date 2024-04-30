using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceXPinc.Models;
using ServiceXPinc.Models.RequestModel;
using ServiceXPinc.Services.Interfaces;

namespace ServiceXPinc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestmentProductController : ControllerBase
    {
        private readonly IInvestmentProductService _investmentProductService;
        public InvestmentProductController(IInvestmentProductService investmentProductService)
        {
            _investmentProductService = investmentProductService;
        }

        [HttpGet]
        public async Task<IActionResult> ListInvestmentProductsAsync()
        {
            return StatusCode(200, await _investmentProductService.ListInvestmentProductsAsync());
        }

        [HttpGet("{investmentProductId}")]
        public async Task<IActionResult> GetInvestmentProductByIdAsync(Guid investmentProductId)
        {
            return StatusCode(200, await _investmentProductService.GetInvestmentProductByIdAsync(investmentProductId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateInvestmentProductAsync(InvestmentProductCreatedRequest investmentProduct)
        {
            return StatusCode(201, await _investmentProductService.CreateInvestmentProductAsync(investmentProduct));
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateInvestmentProductAsync(InvestmentProductUpdatedRequest investmentProduct)
        {
            return StatusCode(200, await _investmentProductService.UpdateInvestmentProductAsync(investmentProduct));
        }

        [HttpDelete("{investmentProductId}")]
        public IActionResult DeleteInvestmentProduct(Guid investmentProductId)
        {
            _investmentProductService.DeleteInvestmentProduct(investmentProductId);
            return StatusCode(200);
        }
    }
}
