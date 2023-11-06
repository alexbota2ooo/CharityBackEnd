using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharityAPI.Entities
{
    public class CharityReviews
    {
        [Key]
        public int Id { get; set; }
        public int CharityId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Review { get; set; }
        public DateTime Date { get; set; }

        public virtual Charities Charity { get; set; }
        public virtual Users User { get; set; }
    }
}
