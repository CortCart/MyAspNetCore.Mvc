

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Photo.Model;

namespace Photo.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Image> Images { get; set; }

        public DbSet<Photograph> Photographs { get; set; }

        public DbSet<Camera> Cameras { get; set; }

        public DbSet<Ad> Ads { get; set; }

        public DbSet<Dealer> Dealers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder
            //    .Entity<Camera>()
            //    .HasOne(c => c.Dealer)
            //    .WithMany(c => c.Cameras)
            //    .HasForeignKey(c => c.DealerId)
                //.OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .Entity<Dealer>()
            //    .HasMany(c => c.Cameras)
            //    .WithOne(c => c.Dealer)
            //    .HasForeignKey(c => c.DealerId)
            //    .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Image>()
                .HasOne(c => c.Camera)
                .WithMany(c => c.Imgs)
                .HasForeignKey(c => c.CameraId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(builder);
        }
    }
}