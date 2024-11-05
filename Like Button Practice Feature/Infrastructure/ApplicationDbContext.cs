using Norebase_Like_Feature_Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Norebase_Like_Feature_Challenge.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article { Id = 1, Title = "Exploring the Future of Cryptocurrency in Nigeria", LikeCount = 5, DateCreated = DateTime.Now },
                new Article { Id = 2, Title = "IoT: Transforming Smart Homes in Urban Nigeria", LikeCount = 5, DateCreated = DateTime.Now },
                new Article { Id = 3, Title = "Cloud Computing: A Game Changer for Nigerian Startups", LikeCount = 5, DateCreated = DateTime.Now },
                new Article { Id = 4, Title = "Artificial Intelligence and its Impact on Nigeria’s Economy", LikeCount = 5, DateCreated = DateTime.Now },
                new Article { Id = 5, Title = "The Role of Blockchain Technology in Enhancing Security", LikeCount = 5, DateCreated = DateTime.Now },
                new Article { Id = 6, Title = "Cybersecurity Trends: Safeguarding Data in the Digital Age", LikeCount = 5, DateCreated = DateTime.Now },
                new Article { Id = 7, Title = "The Rise of Fintech: Innovations Shaping the Banking Sector", LikeCount = 5, DateCreated = DateTime.Now }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Chinedu Okafor" },
                new User { Id = 2, Name = "Amaka Nwankwo" },
                new User { Id = 3, Name = "Emeka Ibe" },
                new User { Id = 4, Name = "Ngozi Nwosu" },
                new User { Id = 5, Name = "Tunde Adebayo" },
                new User { Id = 6, Name = "Sola Bakare" },
                new User { Id = 7, Name = "Adaobi Eze" }
            );

            modelBuilder.Entity<Like>().HasData(
                new Like { Id = 1, UserId = 1, ArticleId = 1, LikedAt = DateTime.UtcNow },
                new Like { Id = 2, UserId = 1, ArticleId = 2, LikedAt = DateTime.UtcNow },
                new Like { Id = 3, UserId = 1, ArticleId = 3, LikedAt = DateTime.UtcNow },
                new Like { Id = 4, UserId = 1, ArticleId = 4, LikedAt = DateTime.UtcNow },
                new Like { Id = 5, UserId = 1, ArticleId = 5, LikedAt = DateTime.UtcNow },
                new Like { Id = 6, UserId = 2, ArticleId = 1, LikedAt = DateTime.UtcNow },
                new Like { Id = 7, UserId = 2, ArticleId = 3, LikedAt = DateTime.UtcNow },
                new Like { Id = 8, UserId = 2, ArticleId = 4, LikedAt = DateTime.UtcNow },
                new Like { Id = 9, UserId = 2, ArticleId = 5, LikedAt = DateTime.UtcNow },
                new Like { Id = 10, UserId = 2, ArticleId = 6, LikedAt = DateTime.UtcNow },
                new Like { Id = 11, UserId = 3, ArticleId = 1, LikedAt = DateTime.UtcNow },
                new Like { Id = 12, UserId = 3, ArticleId = 2, LikedAt = DateTime.UtcNow },
                new Like { Id = 13, UserId = 3, ArticleId = 3, LikedAt = DateTime.UtcNow },
                new Like { Id = 14, UserId = 3, ArticleId = 4, LikedAt = DateTime.UtcNow },
                new Like { Id = 15, UserId = 3, ArticleId = 5, LikedAt = DateTime.UtcNow },
                new Like { Id = 16, UserId = 3, ArticleId = 7, LikedAt = DateTime.UtcNow },
                new Like { Id = 17, UserId = 4, ArticleId = 1, LikedAt = DateTime.UtcNow },
                new Like { Id = 18, UserId = 4, ArticleId = 2, LikedAt = DateTime.UtcNow },
                new Like { Id = 19, UserId = 4, ArticleId = 6, LikedAt = DateTime.UtcNow },
                new Like { Id = 20, UserId = 4, ArticleId = 7, LikedAt = DateTime.UtcNow },
                new Like { Id = 21, UserId = 4, ArticleId = 5, LikedAt = DateTime.UtcNow },
                new Like { Id = 22, UserId = 5, ArticleId = 3, LikedAt = DateTime.UtcNow },
                new Like { Id = 23, UserId = 5, ArticleId = 4, LikedAt = DateTime.UtcNow },
                new Like { Id = 24, UserId = 5, ArticleId = 6, LikedAt = DateTime.UtcNow },
                new Like { Id = 25, UserId = 5, ArticleId = 1, LikedAt = DateTime.UtcNow },
                new Like { Id = 26, UserId = 5, ArticleId = 7, LikedAt = DateTime.UtcNow },
                new Like { Id = 27, UserId = 6, ArticleId = 2, LikedAt = DateTime.UtcNow },
                new Like { Id = 28, UserId = 6, ArticleId = 3, LikedAt = DateTime.UtcNow },
                new Like { Id = 29, UserId = 6, ArticleId = 4, LikedAt = DateTime.UtcNow },
                new Like { Id = 30, UserId = 6, ArticleId = 5, LikedAt = DateTime.UtcNow },
                new Like { Id = 31, UserId = 6, ArticleId = 6, LikedAt = DateTime.UtcNow },
                new Like { Id = 32, UserId = 6, ArticleId = 7, LikedAt = DateTime.UtcNow },
                new Like { Id = 33, UserId = 7, ArticleId = 1, LikedAt = DateTime.UtcNow },
                new Like { Id = 34, UserId = 7, ArticleId = 2, LikedAt = DateTime.UtcNow },
                new Like { Id = 35, UserId = 7, ArticleId = 5, LikedAt = DateTime.UtcNow },
                new Like { Id = 36, UserId = 7, ArticleId = 6, LikedAt = DateTime.UtcNow },
                new Like { Id = 37, UserId = 7, ArticleId = 7, LikedAt = DateTime.UtcNow }
            );

            modelBuilder.Entity<Like>()
                .HasKey(l => new { l.Id });

            modelBuilder.Entity<Like>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Like>()
                .HasOne<Article>()
                .WithMany()
                .HasForeignKey(l => l.ArticleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
