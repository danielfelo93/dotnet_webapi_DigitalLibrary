using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.WebApi.Models
{
    public class DigitalLibraryAppDbContext : IdentityDbContext<IdentityUser>
    {
        public DigitalLibraryAppDbContext(DbContextOptions<DigitalLibraryAppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.AspNetUser)
                .WithMany()
                .HasForeignKey(u => u.AspNetUserId);
                
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);
                
                entity.Property(u => u.LastName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(b => b.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(b => b.Author)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(b => b.User)
                    .WithMany(u => u.Books)
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
