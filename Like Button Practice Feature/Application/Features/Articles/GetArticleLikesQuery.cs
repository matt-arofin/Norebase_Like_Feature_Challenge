using Norebase_Like_Feature_Challenge.Domain.Common;
using Norebase_Like_Feature_Challenge.Domain.Interfaces;
using Norebase_Like_Feature_Challenge.Infrastructure.Services;
using MediatR;

namespace Norebase_Like_Feature_Challenge.Application.Features.Articles
{
    public class GetArticleLikesQuery : IRequest<ApiResponse<ArticleLikesResponse>>
    {
        public int ArticleId { get; set; }
    }

    public class ArticleLikesResponse
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public int LikeCount { get; set; }
        public List<UserLikeDetails> Users { get; set; }
    }

    public class UserLikeDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GetArticleLikesQueryHandler : IRequestHandler<GetArticleLikesQuery, ApiResponse<ArticleLikesResponse>>
    {
        private readonly ILikeService _likeService;

        public GetArticleLikesQueryHandler(ILikeService likeService)
        {
            _likeService = likeService;
        }

        public async Task<ApiResponse<ArticleLikesResponse>> Handle(GetArticleLikesQuery query, CancellationToken cancellationToken)
        {
            var response = await _likeService.GetArticleLikesAsync(query.ArticleId);

            if (response == null)
                return new ApiResponse<ArticleLikesResponse> { Data = null, IsSuccessful = false, StatusCode = "01", Message = $"An error occurred while retrieving likes for Article ID {query.ArticleId}" };

            if (response.LikeCount == 0)
                return new ApiResponse<ArticleLikesResponse> { Data = response, IsSuccessful = true, StatusCode = "00", Message = $"No likes yet for \"{response.Title}\"" };

            return new ApiResponse<ArticleLikesResponse> { Data = response, IsSuccessful = true, StatusCode = "00", Message = $"Likes for article \"{response.Title}\" retrieved successfully" };
        }
    }
}
