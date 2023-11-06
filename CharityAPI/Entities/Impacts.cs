using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CharityAPI.Entities
{
    public class Impacts
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
        public int CharityId { get; set; }

        [ForeignKey("CharityId")]
        public virtual Charities Charity { get; set; }
    }
}
