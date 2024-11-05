using Norebase_Like_Feature_Challenge.Domain.Common;
using Norebase_Like_Feature_Challenge.Domain.Interfaces;
using MediatR;

namespace Norebase_Like_Feature_Challenge.Application.Features.Articles
{
    public class AddArticleCommand : IRequest<ApiResponse<AddArticleResponse>>
    {
        public string Title { get; set; }
    }

    public class AddArticleResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class AddArticleCommandHandler : IRequestHandler<AddArticleCommand, ApiResponse<AddArticleResponse>>
    {
        private readonly IArticleService _articleService;

        public AddArticleCommandHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<ApiResponse<AddArticleResponse>> Handle(AddArticleCommand command, CancellationToken cancellationToken)
        {
            var article = await _articleService.AddArticleAsync(command.Title);

            var response = new AddArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                DateCreated = article.DateCreated
            };

            return new ApiResponse<AddArticleResponse> { Data = response, IsSuccessful = true, StatusCode = "00" };
        }
    }
}
