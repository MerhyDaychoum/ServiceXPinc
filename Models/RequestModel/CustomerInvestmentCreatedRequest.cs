namespace ServiceXPinc.Models.RequestModel
{
    public class CustomerInvestmentCreatedRequest
    {
        public Guid CustomerId { get; set; }
        public Guid InvestmentId { get; set; }
    }
}
