using System.ComponentModel.DataAnnotations;

namespace CharityAPI.Entities
{
    public class VisitorCounts
    {
        [Key]
        public int Id { get; set; }
        public int NumberOfVisits { get; set; }

    }
}
