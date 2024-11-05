using Norebase_Like_Feature_Challenge.Application.Features.Articles;
using Norebase_Like_Feature_Challenge.Application.Features.Users;
using Norebase_Like_Feature_Challenge.Domain.Entities;
using Norebase_Like_Feature_Challenge.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Norebase_Like_Feature_Challenge.Infrastructure.Services
{
    public class LikeService : ILikeService
    {
        private readonly ApplicationDbContext _context;

        public LikeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserLikesResponse>> GetUserLikesAsync(int userId)
        {
            return await _context.Likes
                    .Where(x => x.UserId == userId)
                    .Join(_context.Articles,
                          like => like.ArticleId,
                          article => article.Id,
                          (like, article) => new UserLikesResponse
                          {
                              Title = article.Title,
                              LikedAt = like.LikedAt
                          })
                    .ToListAsync();
        }

        public async Task<ArticleLikesResponse> GetArticleLikesAsync(int articleId)
        {
            var article = await _context.Articles.FindAsync(articleId);

            if (article == null)
                return null;

            var usersWhoLiked = await _context.Likes
                .Where(x => x.ArticleId == articleId)
                .Join(_context.Users,
                      like => like.UserId,
                      user => user.Id,
                      (like, user) => new UserLikeDetails
                      {
                          Id = user.Id,
                          Name = user.Name
                      })
                .ToListAsync();

            return new ArticleLikesResponse
            {
                ArticleId = article.Id,
                Title = article.Title,
                LikeCount = usersWhoLiked.Count,
                Users = usersWhoLiked
            };
        }

    }
}
