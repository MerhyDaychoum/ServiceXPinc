namespace ServiceXPinc.Models.RequestModel
{
    public class InvestmentProductUpdatedRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal InitialInvestment { get; set; }
        public decimal CurrentValue { get; set; }
        public double AnnualReturnValue { get; set; }
        public string RiskLevel { get; set; }
        public DateTime DueDate { get; set; }
    }
}
