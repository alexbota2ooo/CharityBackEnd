using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharityAPI.Entities
{
    public class UserCharityDonations
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int CharityId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DonationDate { get; set; }
        

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }

        [ForeignKey("CharityId")]
        public virtual Charities Charity { get; set; }
    }
}
