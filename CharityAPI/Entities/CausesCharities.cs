using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharityAPI.Entities
{
    public class CausesCharities
    {
        [Key]
        public int Id { get; set; }

        public int CauseId { get; set; }
        public int CharityId { get; set; }


        [ForeignKey("CauseId")]
        public virtual Causes Cause { get; set; }

        [ForeignKey("CharityId")]
        public virtual Charities Charity { get; set; }
    }
}
