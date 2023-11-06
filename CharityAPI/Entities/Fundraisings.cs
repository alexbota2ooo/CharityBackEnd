using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CharityAPI.Entities
{
    public class Fundraisings
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Cause { get; set; }

        public decimal GoalAmount { get; set; }

        public decimal CurrentAmount { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsFeatured { get; set; }        //used to highlight in the future this fundraising

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }
    }
}
