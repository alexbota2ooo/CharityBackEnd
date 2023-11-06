﻿// <auto-generated />
using System;
using CharityAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CharityAPI.Migrations
{
    [DbContext(typeof(CharityDbContext))]
    [Migration("20230424144121_two new column added on Charities table")]
    partial class twonewcolumnaddedonCharitiestable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharityAPI.Entities.Causes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Causes");
                });

            modelBuilder.Entity("CharityAPI.Entities.CausesCharities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CauseId")
                        .HasColumnType("int");

                    b.Property<int>("CharityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CauseId");

                    b.HasIndex("CharityId");

                    b.ToTable("CausesCharities");
                });

            modelBuilder.Entity("CharityAPI.Entities.Charities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnnualReportLink")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("DonationLink")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<decimal?>("Efficiency")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Financials")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<string>("Leadership")
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LeadershipDescription")
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Mail")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("NumFavorites")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal?>("SocialResponsibilityRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Spendings")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TargetGroup")
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal?>("TotalIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Vetted")
                        .HasColumnType("bit");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Charities");
                });

            modelBuilder.Entity("CharityAPI.Entities.CharitiesVettingCriterias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharityId")
                        .HasColumnType("int");

                    b.Property<int>("VettingCriteriaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharityId");

                    b.HasIndex("VettingCriteriaId");

                    b.ToTable("CharitiesVettingCriterias");
                });

            modelBuilder.Entity("CharityAPI.Entities.CharityPrograms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CharityId");

                    b.ToTable("CharityPrograms");
                });

            modelBuilder.Entity("CharityAPI.Entities.CharityReviews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharityId");

                    b.HasIndex("UserId");

                    b.ToTable("CharityReviews");
                });

            modelBuilder.Entity("CharityAPI.Entities.Favorites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharityId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharityId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("CharityAPI.Entities.Fundraisings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cause")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("CurrentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<decimal>("GoalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Fundraisings");
                });

            modelBuilder.Entity("CharityAPI.Entities.Impacts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("Id");

                    b.HasIndex("CharityId");

                    b.ToTable("Impacts");
                });

            modelBuilder.Entity("CharityAPI.Entities.UserCharityDonations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CharityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharityId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCharityDonations");
                });

            modelBuilder.Entity("CharityAPI.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CharityAPI.Entities.VettingCriterias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("Id");

                    b.ToTable("VettingCriterias");
                });

            modelBuilder.Entity("CharityAPI.Entities.VettingDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<int>("VettingCriteriaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VettingCriteriaId");

                    b.ToTable("VettingDetails");
                });

            modelBuilder.Entity("CharityAPI.Entities.CausesCharities", b =>
                {
                    b.HasOne("CharityAPI.Entities.Causes", "Cause")
                        .WithMany("CausesCharities")
                        .HasForeignKey("CauseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CharityAPI.Entities.Charities", "Charity")
                        .WithMany("CausesCharities")
                        .HasForeignKey("CharityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cause");

                    b.Navigation("Charity");
                });

            modelBuilder.Entity("CharityAPI.Entities.CharitiesVettingCriterias", b =>
                {
                    b.HasOne("CharityAPI.Entities.Charities", "Charity")
                        .WithMany()
                        .HasForeignKey("CharityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CharityAPI.Entities.VettingCriterias", "VettingCriteria")
                        .WithMany("CharitiesVettingCriterias")
                        .HasForeignKey("VettingCriteriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Charity");

                    b.Navigation("VettingCriteria");
                });

            modelBuilder.Entity("CharityAPI.Entities.CharityPrograms", b =>
                {
                    b.HasOne("CharityAPI.Entities.Charities", "Charity")
                        .WithMany("CharityPrograms")
                        .HasForeignKey("CharityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Charity");
                });

            modelBuilder.Entity("CharityAPI.Entities.CharityReviews", b =>
                {
                    b.HasOne("CharityAPI.Entities.Charities", "Charity")
                        .WithMany("CharityReviews")
                        .HasForeignKey("CharityId")
                        .IsRequired()
                        .HasConstraintName("FK_CharityReviews_Charity");

                    b.HasOne("CharityAPI.Entities.Users", "User")
                        .WithMany("CharityReviews")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_CharityReviews_User");

                    b.Navigation("Charity");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CharityAPI.Entities.Favorites", b =>
                {
                    b.HasOne("CharityAPI.Entities.Charities", "Charity")
                        .WithMany("Favorites")
                        .HasForeignKey("CharityId")
                        .IsRequired()
                        .HasConstraintName("FK_Favorites_Charity");

                    b.HasOne("CharityAPI.Entities.Users", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Favorites_User");

                    b.Navigation("Charity");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CharityAPI.Entities.Fundraisings", b =>
                {
                    b.HasOne("CharityAPI.Entities.Users", "User")
                        .WithMany("Fundraisings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CharityAPI.Entities.Impacts", b =>
                {
                    b.HasOne("CharityAPI.Entities.Charities", "Charity")
                        .WithMany("Impacts")
                        .HasForeignKey("CharityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Charity");
                });

            modelBuilder.Entity("CharityAPI.Entities.UserCharityDonations", b =>
                {
                    b.HasOne("CharityAPI.Entities.Charities", "Charity")
                        .WithMany("UserCharityDonations")
                        .HasForeignKey("CharityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CharityAPI.Entities.Users", "User")
                        .WithMany("UserCharityDonations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Charity");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CharityAPI.Entities.VettingDetails", b =>
                {
                    b.HasOne("CharityAPI.Entities.VettingCriterias", "VettingCriteria")
                        .WithMany("VettingDetails")
                        .HasForeignKey("VettingCriteriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VettingCriteria");
                });

            modelBuilder.Entity("CharityAPI.Entities.Causes", b =>
                {
                    b.Navigation("CausesCharities");
                });

            modelBuilder.Entity("CharityAPI.Entities.Charities", b =>
                {
                    b.Navigation("CausesCharities");

                    b.Navigation("CharityPrograms");

                    b.Navigation("CharityReviews");

                    b.Navigation("Favorites");

                    b.Navigation("Impacts");

                    b.Navigation("UserCharityDonations");
                });

            modelBuilder.Entity("CharityAPI.Entities.Users", b =>
                {
                    b.Navigation("CharityReviews");

                    b.Navigation("Favorites");

                    b.Navigation("Fundraisings");

                    b.Navigation("UserCharityDonations");
                });

            modelBuilder.Entity("CharityAPI.Entities.VettingCriterias", b =>
                {
                    b.Navigation("CharitiesVettingCriterias");

                    b.Navigation("VettingDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
