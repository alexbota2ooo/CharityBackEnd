using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharityAPI.Entities
{
    public class VettingCriterias
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Name { get; set; }

        public virtual ICollection<VettingDetails> VettingDetails { get; set; }
        public virtual ICollection<CharitiesVettingCriterias> CharitiesVettingCriterias { get; set; }
    }
}
