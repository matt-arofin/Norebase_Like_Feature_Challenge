using Norebase_Like_Feature_Challenge.Application.Features.Likes;
using Norebase_Like_Feature_Challenge.Domain.Entities;
using Norebase_Like_Feature_Challenge.Infrastructure;

namespace Norebase_Like_Feature_Challenge.Domain.Interfaces
{
    public interface IArticleService
    {
        Task<List<Article>> GetArticlesAsync();
        Task<Article> GetArticleByIdAsync(int articleId);
        Task<int> GetArticleLikeCountAsync(int articleId);
        Task<(int likeCount, string message)> UpdateLikesAsync(int articleId, int userId);
        Task<Article> AddArticleAsync(string articleTitle);

    }
}
