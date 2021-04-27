using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TripSimulator.Models
{
    public partial class TripSimulatorContext : DbContext
    {
        public TripSimulatorContext()
        {
        }

        public TripSimulatorContext(DbContextOptions<TripSimulatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TripSimulator;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("CARS");

                entity.Property(e => e.CarId).HasColumnName("carId");

                entity.Property(e => e.CarName)
                    .HasMaxLength(20)
                    .HasColumnName("carName");

                entity.Property(e => e.Mpg).HasColumnName("mpg");

                entity.Property(e => e.TankSize).HasColumnName("tankSize");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("PURCHASES");

                entity.Property(e => e.PurchaseId).HasColumnName("purchaseId");

                entity.Property(e => e.BusinessOrPersonal).HasColumnName("businessOrPersonal");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("TRIPS");

                entity.Property(e => e.TripId).HasColumnName("tripId");

                entity.Property(e => e.CarId).HasColumnName("carId");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Miles).HasColumnName("miles");

                entity.Property(e => e.RoundTrip).HasColumnName("roundTrip");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TRIPS__carId__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
