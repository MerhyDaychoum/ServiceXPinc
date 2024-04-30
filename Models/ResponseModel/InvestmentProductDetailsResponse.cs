namespace ServiceXPinc.Models.ResponseModel
{
    public class InvestmentProductDetailsResponse
    {
        public InvestmentProductDetailsResponse(InvestmentProduct investmentProduct)
        {
            Id = investmentProduct.Id;
            Name = investmentProduct.Name;
            Type = investmentProduct.Type;
            InitialInvestment = investmentProduct.InitialInvestment;
            CurrentValue = investmentProduct.CurrentValue;
            AnnualReturnValue = investmentProduct.AnnualReturnValue;
            RiskLevel = investmentProduct.RiskLevel;
            DueDate = investmentProduct.DueDate;
        }

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
