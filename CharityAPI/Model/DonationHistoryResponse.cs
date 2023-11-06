namespace CharityAPI.Model
{
    public class DonationHistoryResponse
    {
        public int DonationId { get; set; }
        public int UserId { get; set; }
        public int CharityId { get; set; }
        public string? CharityName { get; set; }
        public string? Website { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonationDate { get; set; }
    }
}
