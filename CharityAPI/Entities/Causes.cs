using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharityAPI.Entities
{
    public class Causes
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? ImageUrl { get; set; }

        public virtual ICollection<CausesCharities> CausesCharities { get; set; }
    }
}
