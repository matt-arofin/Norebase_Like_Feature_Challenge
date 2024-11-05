using Norebase_Like_Feature_Challenge.Application.Features.Articles;
using Norebase_Like_Feature_Challenge.Application.Features.Likes;
using Norebase_Like_Feature_Challenge.Domain.Entities;
using Norebase_Like_Feature_Challenge.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Norebase_Like_Feature_Challenge.Infrastructure.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _context;

        private ArticleService()
        {

        }

        public ArticleService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Article>> GetArticlesAsync()
        {

            return await _context.Articles.ToListAsync();
        }

        public async Task<Article> GetArticleByIdAsync(int articleId )
        {
            var article = await _context.Articles.FirstOrDefaultAsync(x => x.Id == articleId);

            return article;
        }

        public async Task<int> GetArticleLikeCountAsync(int articleId)
        {
            var count = _context.Articles.Where(x => x.Id == articleId).Count();

            return count;
        }

        public async Task<(int likeCount, string message)> UpdateLikesAsync(int articleId, int userId)
        {
            var article = await _context.Articles.FindAsync(articleId);
            var currentCount = article.LikeCount;

            if (article == null)
            {
                throw new Exception($"Article not found: Invalid artile ID {articleId}");
            }

            var existingLike = await _context.Likes
                .FirstOrDefaultAsync(x => x.ArticleId == articleId && x.UserId == userId);

            if (existingLike != null)
            {
                _context.Likes.Remove(existingLike);
                article.LikeCount--;
            }
            else
            {
                var newLike = new Like
                {
                    ArticleId = articleId,
                    UserId = userId,
                    LikedAt = DateTime.Now
                };

                _context.Likes.Add(newLike);
                article.LikeCount++;
            }
            
            await _context.SaveChangesAsync();

            var message = article.LikeCount > currentCount ? "Article like added successfully" : "Article like successfully removed";
            
            return (article.LikeCount, message);
        }

        public async Task<Article> AddArticleAsync(string articleTitle)
        {
            var article = new Article { 
                Title = articleTitle,
                LikeCount = 0,
                DateCreated = DateTime.UtcNow,
            };
            
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }
    }
}
