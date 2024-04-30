using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceXPinc.Models;
using ServiceXPinc.Models.RequestModel;
using ServiceXPinc.Models.ResponseModel;
using ServiceXPinc.Services.Interfaces;

namespace ServiceXPinc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerInvestmentController : ControllerBase
    {
        private readonly ICustomerInvestmentService _customerInvestmentService;
        public CustomerInvestmentController(ICustomerInvestmentService customerInvestmentService)
        {
            _customerInvestmentService = customerInvestmentService;
        }

        [HttpGet]
        public async Task<IActionResult> ListCustomerInvestmentAsync() 
        {
            return StatusCode(200, await _customerInvestmentService.ListCustomerInvestmentAsync());
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerInvestmentByCustomerIdAsync(Guid customerId)
        {
            var result = await _customerInvestmentService.GetCustomerInvestmentByCustomerIdAsync(customerId);
            return StatusCode(200, result);
        }

        [HttpPost("/buy")]
        public async Task<IActionResult> BuyInvestmentAsync(CustomerInvestmentCreatedRequest request)
        {
            return StatusCode(200, await _customerInvestmentService.BuyInvestmentAsync(request));
        }

        [HttpPatch("/sell/{customerInvestmentId}")]
        public async Task<IActionResult> SellInvestmentAsync(Guid customerInvestmentId)
        {
            _customerInvestmentService.SellInvestmentAsync(customerInvestmentId);
            return StatusCode(200);
        }
    }
}
