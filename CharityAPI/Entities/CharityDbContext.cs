using Microsoft.EntityFrameworkCore;

namespace CharityAPI.Entities
{
    public class CharityDbContext : DbContext
    {
        public CharityDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Charities> Charities { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<CharityReviews> CharityReviews { get; set; }
        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<CharityPrograms> CharityPrograms { get; set; }
        public virtual DbSet<Fundraisings> Fundraisings { get; set; }
        public virtual DbSet<Causes> Causes { get; set; }
        public virtual DbSet<CausesCharities> CausesCharities { get; set; }
        public virtual DbSet<VettingCriterias> VettingCriterias { get; set; }
        public virtual DbSet<VettingDetails> VettingDetails { get; set; }
        public virtual DbSet<CharitiesVettingCriterias> CharitiesVettingCriterias { get; set; }
        public virtual DbSet<UserCharityDonations> UserCharityDonations { get; set; }
        public virtual DbSet<Impacts> Impacts { get; set; }
        public virtual DbSet<VisitorCounts> VisitorCounts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Charities>()
                .Property(b => b.NumFavorites)
                .HasDefaultValue(0);

            modelBuilder.Entity<CharityReviews>(entity =>
            {
                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.CharityReviews)
                    .HasForeignKey(d => d.CharityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharityReviews_Charity");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CharityReviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharityReviews_User");
            });

            modelBuilder.Entity<Favorites>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favorites_User");

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.CharityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favorites_Charity");
            });
        }
    }
}
