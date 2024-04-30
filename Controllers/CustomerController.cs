using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceXPinc.Models;
using ServiceXPinc.Models.RequestModel;
using ServiceXPinc.Services.Interfaces;

namespace ServiceXPinc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, IConfiguration configuration, ICustomerService customerService)
        {
            _logger = logger;
            _configuration = configuration;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> ListCustomerAsync()
        {
            return StatusCode(200, await _customerService.ListCustomersAsync());
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerByIdAsync(Guid customerId)
        {
            return StatusCode(200, await _customerService.GetCustomerByIdAsync(customerId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync(CustomerCreatedRequest request)
        {
            return StatusCode(201, await _customerService.CreateCustomerAsync(request));
        }
    }
}
