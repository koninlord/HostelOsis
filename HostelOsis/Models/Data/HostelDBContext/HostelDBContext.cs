using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HostelOsis.Models.Data.HostelDBContext
{
    public partial class HostelDBContext : DbContext
    {
        public HostelDBContext()
        {
        }

        public HostelDBContext(DbContextOptions<HostelDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingDetails> BookingDetails { get; set; }
        public virtual DbSet<Floor> Floor { get; set; }
        public virtual DbSet<HostelOccupant> HostelOccupant { get; set; }
        public virtual DbSet<OccupImage> OccupImage { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<BookingDetails>(entity =>
            {
                entity.HasKey(e => e.BillId)
                    .HasName("PK__BookingD__11F2FC4A266DAABC");

                entity.Property(e => e.BillId).HasColumnName("BillID");

                entity.Property(e => e.ArrivalDate).HasColumnType("datetime");

                entity.Property(e => e.DepartureDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookingDe__RoomI__398D8EEE");
            });

            modelBuilder.Entity<Floor>(entity =>
            {
                entity.Property(e => e.FloorId).HasColumnName("FloorID");

                entity.Property(e => e.FloorName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HostelOccupant>(entity =>
            {
                entity.HasKey(e => e.OccupantId);

                entity.Property(e => e.OccupantId).HasColumnName("OccupantID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.HostelOccupant)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomHostelOccupant");
            });

            modelBuilder.Entity<OccupImage>(entity =>
            {
                entity.HasKey(e => e.OccupImage1)
                    .HasName("PK__OccupIma__82B66A99C137B133");

                entity.Property(e => e.OccupImage1).HasColumnName("OccupImage");

                entity.Property(e => e.Image).HasMaxLength(50);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasIndex(e => e.FloorId)
                    .HasName("Ref1326");

                entity.HasIndex(e => e.RoomTypeId)
                    .HasName("Ref1025");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.FloorId).HasColumnName("FloorID");

                entity.Property(e => e.IsAvailable)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

                entity.HasOne(d => d.Floor)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.FloorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FloorRoom");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomTypeRoom");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
