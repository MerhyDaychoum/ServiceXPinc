using System.ComponentModel.DataAnnotations;

namespace ServiceXPinc.Models
{
    public class CustomerInvestment
    {
        public CustomerInvestment(Guid customerId, Guid investmentId)
        {
            CustomerId = customerId;
            InvestmentId = investmentId;
        }

        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid InvestmentId { get; set; }
        public DateTime CreatedDate  { get; set; }
    }
}
