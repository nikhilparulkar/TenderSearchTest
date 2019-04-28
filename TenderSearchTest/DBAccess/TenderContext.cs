using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TenderSearchTest.DBAccess
{
    public partial class TenderContext : DbContext
    {
        public TenderContext()
        {
        }

        public TenderContext(DbContextOptions<TenderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TenderDetails> TenderDetails { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(ConfigReader.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenderDetails>(entity =>
            {
                entity.HasKey(e => e.ReferenceNumber);

                entity.Property(e => e.ReferenceNumber).ValueGeneratedNever();

                entity.Property(e => e.ClosingDate).HasColumnType("date");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TenderDetails)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Passwd).IsRequired();
            });
        }
    }
}
