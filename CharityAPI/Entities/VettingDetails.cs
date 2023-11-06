using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CharityAPI.Entities
{
    public class VettingDetails
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Name { get; set; }
        public int VettingCriteriaId { get; set; }

        [ForeignKey("VettingCriteriaId")]
        public virtual VettingCriterias VettingCriteria { get; set; }
    }
}
