using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharityAPI.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Role { get; set; }

        public virtual ICollection<CharityReviews> CharityReviews { get; set; }
        public virtual ICollection<Favorites> Favorites { get; set; }
        public virtual ICollection<Fundraisings> Fundraisings { get; set; }
        public virtual ICollection<UserCharityDonations> UserCharityDonations { get; set; }
    }
}
