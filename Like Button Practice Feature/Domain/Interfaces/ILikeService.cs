using Norebase_Like_Feature_Challenge.Application.Features.Articles;
using Norebase_Like_Feature_Challenge.Application.Features.Users;
using Norebase_Like_Feature_Challenge.Domain.Entities;

namespace Norebase_Like_Feature_Challenge.Domain.Interfaces
{
    public interface ILikeService
    {
        Task<ArticleLikesResponse> GetArticleLikesAsync(int articleId);
        Task<List<UserLikesResponse>> GetUserLikesAsync(int userId);
    }
}
