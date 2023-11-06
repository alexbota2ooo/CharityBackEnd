using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CharityAPI.Entities
{
    public class CharitiesVettingCriterias
    {
        [Key]
        public int Id { get; set; }

        public int CharityId { get; set; }
        public int VettingCriteriaId { get; set; }


        [ForeignKey("CharityId")]
        public virtual Charities Charity { get; set; }

        [ForeignKey("VettingCriteriaId")]
        public virtual VettingCriterias VettingCriteria { get; set; }
    }
}
