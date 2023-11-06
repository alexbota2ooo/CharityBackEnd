using CharityAPI.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharityAPI.Model
{
    public class VettingCriteriaResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual List<VettingDetailsResponse> VettingDetailsResponse { get; set; } = new List<VettingDetailsResponse>();
    }

    public class VettingDetailsResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
