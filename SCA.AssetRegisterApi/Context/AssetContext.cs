using Microsoft.EntityFrameworkCore;
using SCA.AssetRegisterApi.Models;

namespace SCA.AssetRegisterApi.Context
{
    public class AssetContext: DbContext
    {
        public AssetContext(DbContextOptions<AssetContext> options): base(options)
        { }

        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<Asset> Assets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetType>().HasKey(c => c.Id);
            modelBuilder.Entity<AssetType>().Property(c => c.Name).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<AssetType>().Property(c => c.NeedMaintenance).HasDefaultValue(true).IsRequired();

            modelBuilder.Entity<Asset>().HasKey(c => c.Id);
            modelBuilder.Entity<Asset>().Property(c => c.Name).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Asset>().Property(c => c.NeedMaintenance).IsRequired();
            modelBuilder.Entity<Asset>().Property(c => c.OperationDate).IsRequired();
            modelBuilder.Entity<Asset>().Property(c => c.AcquisitionDate).IsRequired();
            modelBuilder.Entity<Asset>().Property(c => c.Status).HasDefaultValue(true).IsRequired();

            modelBuilder.Entity<AssetType>()
              .HasMany(g => g.Assets)
                .WithOne(c => c.AssetType)
                .IsRequired()
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
