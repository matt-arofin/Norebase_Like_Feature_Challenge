using Norebase_Like_Feature_Challenge.Application.Features.Articles;
using Norebase_Like_Feature_Challenge.Application.Features.Likes;
using Norebase_Like_Feature_Challenge.Domain.Common;
using Norebase_Like_Feature_Challenge.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Norebase_Like_Feature_Challenge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly ISender _mediatr;

        public ArticleController(ISender mediatr, ILogger<ArticleController> logger)
        {
            _logger = logger;
            _mediatr = mediatr;
        }

        /// <summary>
        /// Retrieves a list of all articles.
        /// </summary>
        /// <returns>An article list response containing the list of articles in the database.</returns>
        [HttpGet("/Articles")]
        [ProducesResponseType(typeof(ApiResponse<List<Article>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllArticles()
        {
            var query = new GetArticlesQuery();
            var result = await _mediatr.Send(query);

            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        /// <summary>
        /// Retrieves the list of users who have liked a specified article.
        /// </summary>
        /// <param name="articleId">The unique identifier of the article.</param>
        /// <returns>A single article containing the article ID, title, like count, and a list of users who liked it.</returns>
        [HttpGet("/Article/{articleId}/Likes")]
        [ProducesResponseType(typeof(ApiResponse<ArticleLikesResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetArticleLikes([FromRoute] int articleId)
        {
            var query = new GetArticleLikesQuery { ArticleId = articleId };
            var result = await _mediatr.Send(query);

            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }


        /// <summary>
        /// Gets an article by its ID along with associated metadata.
        /// </summary>
        /// <param name="articleId">The unique identifier of the article.</param>
        /// <returns>An article response containing the article and its metadata if found, otherwise an error response.</returns>
        [HttpGet("/Article/{articleId}")]
        [ProducesResponseType(typeof(ApiResponse<Article>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<Article?>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> GetArticleInfo([FromRoute] int articleId)
        {
            var query = new GetArticleDetailsQuery { ArticleId = articleId};
            var result = await _mediatr.Send(query);

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        /// <summary>
        /// Registers a "like" action for a specified article by a user.
        /// </summary>
        /// <param name="command">The <see cref="LikeArticleCommand"/> containing details of the article and user.</param>
        /// <returns>An article response indicating success with the updated like count, or an error response if the action fails.</returns>
        [HttpPost($"/Article/Like")]
        [ProducesResponseType(typeof(ApiResponse<LikeArticleResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> LikeArticle(LikeArticleCommand command)
        {
            var result = await _mediatr.Send(command);

            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        /// <summary>
        /// Adds a new article to the database.
        /// </summary>
        /// <param name="command">The <see cref="AddArticleCommand"/> containing details of the article to be created.</param>
        /// <returns>An article response containing the newly created article's details, including its assigned ID.</returns>
        [HttpPost("/Article/New")]
        [ProducesResponseType(typeof(ApiResponse<AddArticleResponse>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddArticle(AddArticleCommand command)
        {
            var result = await _mediatr.Send(command);

            return result.IsSuccessful ? CreatedAtAction(nameof(AddArticle), new { articleId = result.Data.Id }, result) : BadRequest(result);
        }


    }
}
