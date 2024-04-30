namespace ServiceXPinc.Models.ResponseModel
{
    public class CustomerDetailsResponse
    {
        public CustomerDetailsResponse(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Email = customer.Email;
            BallanceInWallet = customer.BallanceInWallet;
            RegistrationDate = customer.RegistrationDate;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal BallanceInWallet { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
