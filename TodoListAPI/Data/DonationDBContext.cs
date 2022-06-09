using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TodoListAPI.Models;

namespace TodoListAPI.Data
{
    public partial class DonationDBContext : DbContext
    {
        public DonationDBContext()
        {
        }

        public DonationDBContext(DbContextOptions<DonationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dcandidate> Dcandidates { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Dcandidate>(entity =>
            {
                entity.ToTable("dcandidates");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Lvl)
                    .HasMaxLength(255)
                    .HasColumnName("lvl");

                entity.Property(e => e.Task)
                    .HasMaxLength(255)
                    .HasColumnName("task");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
