using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("announcement");
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AnnouncementConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired();

            builder
                .HasIndex(x => x.Name)
                .HasDatabaseName("Index_Name");

            builder
                .Property(x => x.IsAdmin)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }

    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Number)
                .ValueGeneratedOnAdd();

            builder
                .HasIndex(x => x.Number)
                .HasDatabaseName("Index_Number")
                .IsUnique();

            builder
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(y => y.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .HasIndex(x => x.UserId)
                .HasDatabaseName("Index_UserId");

            builder
                .Property(x => x.Text)
                .IsRequired();

            builder
                .Property(x => x.ImageUri)
                .IsRequired();

            builder
                .Property(x => x.Rating)
                .IsRequired();

            builder
                .HasIndex(x => x.Rating)
                .HasDatabaseName("Index_Rating");

            builder
                .Property(x => x.Created)
                .IsRequired();

            builder
                .Property(x => x.Expity)
                .IsRequired();
        }
    }
}
