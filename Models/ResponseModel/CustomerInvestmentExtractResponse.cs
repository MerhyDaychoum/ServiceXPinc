namespace ServiceXPinc.Models.ResponseModel
{
    public class CustomerInvestmentExtractResponse
    {
        public CustomerInvestmentExtractResponse(Guid customerId, string customerName, string customerEmail, List<InvestmentProductDetailsResponse> investmentProducts)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            InvestmentProducts = investmentProducts;
        }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<InvestmentProductDetailsResponse> InvestmentProducts { get; set; }
    }
}
