using System;
using System.Collections.Generic;
using System.Text;
using LoyalSRazor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoyalSRazor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserCoupons>().HasKey(sc => new { sc.UserId, sc.CouponId });
            modelBuilder.Entity<CheckIn>().HasKey(sc => new { sc.UserId, sc.PlaceId, sc.date_of_check });

            modelBuilder.Entity<UserCoupons>()
                .HasOne<MobileAppUser>(sc => sc.MobileAppUser)
                .WithMany(s => s.UserCoupons)
                .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<UserCoupons>()
                .HasOne<Coupon>(sc => sc.Coupon)
                .WithMany(s => s.UserCoupons)
                .HasForeignKey(sc => sc.CouponId);

            modelBuilder.Entity<CheckIn>()
                .HasOne<MobileAppUser>(sc => sc.MobileAppUser)
                .WithMany(s => s.CheckIns)
                .HasForeignKey(sc => sc.UserId);


            modelBuilder.Entity<CheckIn>()
                .HasOne<Place>(sc => sc.Place)
                .WithMany(s => s.CheckIns)
                .HasForeignKey(sc => sc.PlaceId);
        }

        public DbSet<MobileAppUser> MobileAppUsers { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<UserCoupons> UserCoupons { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
    }
}
