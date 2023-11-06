namespace CharityAPI.Model
{
    public class DonationRequest
    {
        public int UserId { get; set; }
        public int CharityId { get; set; }
        public decimal Amount { get; set; }
    }
}
