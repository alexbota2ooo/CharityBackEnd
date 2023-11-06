using System.ComponentModel.DataAnnotations;

namespace CharityAPI.Entities
{
    public class Favorites
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int CharityId { get; set; }

        public virtual Users User { get; set; }
        public virtual Charities Charity { get; set; }
    }
}
