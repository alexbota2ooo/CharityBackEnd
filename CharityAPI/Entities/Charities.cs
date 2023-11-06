using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharityAPI.Entities
{
    public class Charities
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? PhoneNumber { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string? Mail { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? TargetGroup { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? Leadership { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? LeadershipDescription { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Website { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Financials { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string? AnnualReportLink { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? ImageUrl { get; set; }

        public bool Vetted { get; set; }
        public bool IsFeatured { get; set; }    //used for future prioritized charities
        public decimal? Efficiency { get; set; }
        public decimal? SocialResponsibilityRating { get; set; }

        [DefaultValue(0)]
        public int NumFavorites { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string? DonationLink { get; set; }

        public decimal? TotalIncome { get; set; }
        public decimal? Spendings { get; set; }


        public virtual ICollection<CharityReviews> CharityReviews { get; set; }
        public virtual ICollection<Favorites> Favorites { get; set; }
        public virtual ICollection<CharityPrograms> CharityPrograms { get; set; }
        public virtual ICollection<CausesCharities> CausesCharities { get; set; }
        public virtual ICollection<UserCharityDonations> UserCharityDonations { get; set; }
        public virtual ICollection<Impacts> Impacts { get; set; }
    }
}
