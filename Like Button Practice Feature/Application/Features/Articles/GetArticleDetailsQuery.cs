using Norebase_Like_Feature_Challenge.Domain.Common;
using Norebase_Like_Feature_Challenge.Domain.Interfaces;
using MediatR;

namespace Norebase_Like_Feature_Challenge.Application.Features.Articles
{
    public class GetArticleDetailsQuery : IRequest<ApiResponse<GetArticleDetailsResponse>>
    {
        public int ArticleId { get; set; }
    }

    public class GetArticleDetailsResponse
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public int LikeCount { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class GetArticleInfoQueryHandler : IRequestHandler<GetArticleDetailsQuery, ApiResponse<GetArticleDetailsResponse>>
    {
        private readonly IArticleService _articleService;

        public GetArticleInfoQueryHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<ApiResponse<GetArticleDetailsResponse>> Handle(GetArticleDetailsQuery query, CancellationToken cancellationToken)
        {
            var article = await _articleService.GetArticleByIdAsync(query.ArticleId);

            if (article == null)
                return new ApiResponse<GetArticleDetailsResponse> { IsSuccessful = false, Message = "Article not found" };

            var response = new GetArticleDetailsResponse
            {
                ArticleId = article.Id,
                Title = article.Title,
                LikeCount = article.LikeCount,
                DateCreated = article.DateCreated
            };

            return new ApiResponse<GetArticleDetailsResponse> { Data = response, IsSuccessful = true, StatusCode = "00", Message = "Article details retrieved successfully" };
        }
    }
}
