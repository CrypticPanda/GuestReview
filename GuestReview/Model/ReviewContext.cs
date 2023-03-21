using Microsoft.EntityFrameworkCore;

namespace GuestReview.Model
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options)
        : base(options)
        {
        }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Review>(entity =>
            {
                entity
                .ToTable("Review")
                .HasKey(k => k.Id);

                entity
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            });
        }
    }
}
