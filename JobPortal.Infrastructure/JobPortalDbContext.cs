using System;
using System.Collections.Generic;
using JobPortal.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Infrastructure
{
    public partial class JobPortalDbContext : IdentityDbContext<ApplicationUser>
    {
        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Ensure Identity tables are created

            // Job Table Mapping (from database-first)
            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.JobId).HasName("PK__Jobs__056690C2BBC87E9C");

                entity.Property(e => e.AddedDate).HasColumnType("datetime");
                entity.Property(e => e.ApplyLink).HasMaxLength(200);
                entity.Property(e => e.ApplyType).HasMaxLength(50);
                entity.Property(e => e.CompanyLogoUrl).HasMaxLength(300);
                entity.Property(e => e.Ctc).HasMaxLength(50).HasColumnName("CTC");
                entity.Property(e => e.Domain).HasMaxLength(100);
                entity.Property(e => e.Experience).HasMaxLength(50);
                entity.Property(e => e.ExpireDate).HasColumnType("datetime");
                entity.Property(e => e.JobCompanyName).HasMaxLength(100);
                entity.Property(e => e.JobTitle).HasMaxLength(100);
                entity.Property(e => e.JobType).HasMaxLength(100);
                entity.Property(e => e.Location).HasMaxLength(100);
                entity.Property(e => e.Qualification).HasMaxLength(100);
            });

            // Role Seeding
            var adminRoleId = "a71a55d6-99d7-4123-b4e0-1218ecb90e3e";
            var userRoleId = "c309fa92-2123-47be-b397-a1c77adb502c";

            modelBuilder.Entity<IdentityRole>().HasData(new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Id = userRoleId,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = userRoleId
                }
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
