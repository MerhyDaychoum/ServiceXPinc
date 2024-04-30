using System.ComponentModel.DataAnnotations;

namespace ServiceXPinc.Models
{
    public class Customer
    {
        public Customer(string name, string email, decimal ballanceInWallet)
        {
            Name = name;
            Email = email;
            BallanceInWallet = ballanceInWallet;
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal BallanceInWallet  { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
