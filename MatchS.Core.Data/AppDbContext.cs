using MatchS.Core.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace MatchS.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Participant> Participants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Advert - User (Many-to-One)
            modelBuilder.Entity<Advert>()
                .HasOne(a => a.User)
                .WithMany(u => u.Adverts)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Advert - Category (Many-to-One)
            modelBuilder.Entity<Advert>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Adverts)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Comment - User (Many-to-One)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Comment - Advert (Many-to-One)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Advert)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.AdvertId)
                .OnDelete(DeleteBehavior.Restrict);

            // Participant - User (Many-to-One)
            modelBuilder.Entity<Participant>()
                .HasOne(p => p.User)
                .WithMany(u => u.Participants)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Participant - Advert (Many-to-One)
            modelBuilder.Entity<Participant>()
                .HasOne(p => p.Advert)
                .WithMany(a => a.Participants)
                .HasForeignKey(p => p.AdvertId)
                .OnDelete(DeleteBehavior.Restrict);

            // Message - Sender (Many-to-One)
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            // Message - Receiver (Many-to-One)
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}