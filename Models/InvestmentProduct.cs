using System.ComponentModel.DataAnnotations;

namespace ServiceXPinc.Models
{
    public class InvestmentProduct
    {
        public InvestmentProduct(string name, string type, decimal initialInvestment, decimal currentValue, double annualReturnValue, string riskLevel)
        {
            Name = name;
            Type = type;
            InitialInvestment = initialInvestment;
            CurrentValue = currentValue;
            AnnualReturnValue = annualReturnValue;
            RiskLevel = riskLevel;
        }

        [Key]
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
