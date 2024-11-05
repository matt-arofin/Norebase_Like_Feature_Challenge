using Norebase_Like_Feature_Challenge.Domain.Common;
using Norebase_Like_Feature_Challenge.Domain.Entities;
using Norebase_Like_Feature_Challenge.Domain.Interfaces;
using Norebase_Like_Feature_Challenge.Infrastructure;
using MediatR;
using System;

namespace Norebase_Like_Feature_Challenge.Application.Features.Articles
{
    public class GetArticlesQuery : IRequest<ApiResponse<List<Article>>>
    {
    }

    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, ApiResponse<List<Article>>>
    {
        private readonly IArticleService _articleService;

        public GetArticlesQueryHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<ApiResponse<List<Article>>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await _articleService.GetArticlesAsync();

            if (articles.Count == 0)
            {
                return new ApiResponse<List<Article>>
                {
                    IsSuccessful = true,
                    StatusCode = "00",
                    Message = "No articles found."
                };
            }

            return new ApiResponse<List<Article>>
            {
                Data = articles,
                IsSuccessful = true,
                StatusCode = "00",
                Message = "Articles retrieved successfully."
            };
        }
    }

}
