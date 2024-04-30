namespace ServiceXPinc.Models.ResponseModel
{
    public class CustomerInvestmentDetailsResponse
    {
        public CustomerInvestmentDetailsResponse(CustomerInvestment? customerInvestment)
        {
            Id = customerInvestment.Id;
            CustomerId = customerInvestment.CustomerId;
            InvestmentId = customerInvestment.InvestmentId;
            CreatedDate = customerInvestment.CreatedDate;
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid InvestmentId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
