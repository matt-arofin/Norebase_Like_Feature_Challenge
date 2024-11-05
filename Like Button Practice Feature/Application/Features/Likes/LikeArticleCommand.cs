using Norebase_Like_Feature_Challenge.Domain.Common;
using Norebase_Like_Feature_Challenge.Domain.Interfaces;
using MediatR;

namespace Norebase_Like_Feature_Challenge.Application.Features.Likes
{
    public class LikeArticleCommand : IRequest<ApiResponse<LikeArticleResponse>>
    {
        public int ArticleId { get; set; }
        public int UserId { get; set; }
    }

    public class LikeArticleResponse
    {
        public int UserId { get; set; }
        public int ArticleId { get; set; }
        public int LikeCount { get; set; }
    }

    public class LikeArticleCommandHandler : IRequestHandler<LikeArticleCommand, ApiResponse<LikeArticleResponse>>
    {
        private readonly IArticleService _articleService;

        public LikeArticleCommandHandler(IArticleService articleSerivce)
        {
            _articleService = articleSerivce;
        }

        public async Task<ApiResponse<LikeArticleResponse>> Handle(LikeArticleCommand command, CancellationToken cancellationToken)
        {
            var updateLikeCount = await _articleService.UpdateLikesAsync(command.ArticleId, command.UserId);

            var response = new LikeArticleResponse
            {
                UserId = command.UserId,
                ArticleId = command.ArticleId,
                LikeCount = updateLikeCount.likeCount
            };

            return new ApiResponse<LikeArticleResponse>
            {
                Data = response,
                IsSuccessful = true,
                StatusCode = "00",
                Message = updateLikeCount.message
            };
        }
    }
}
