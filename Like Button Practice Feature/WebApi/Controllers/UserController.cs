using Norebase_Like_Feature_Challenge.Application.Features.Users;
using Norebase_Like_Feature_Challenge.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Norebase_Like_Feature_Challenge.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ISender _mediatr;

        public UserController(ISender mediatr, ILogger<UserController> logger)
        {
            _logger = logger;
            _mediatr = mediatr;
        }

        // add user, get user likes
        /// <summary>
        /// Adds a new user to the database with the specified name.
        /// </summary>
        /// <param name="command">The command containing the user's name.</param>
        /// <returns>The created user with their assigned ID.</returns>
        [HttpPost("/User/New")]
        [ProducesResponseType(typeof(ApiResponse<AddUserResponse>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddUser(AddUserCommand command)
        {
            var result = await _mediatr.Send(command);

            return result.IsSuccessful ? CreatedAtAction(nameof(AddUser), new { userId = result.Data.Id }, result) : BadRequest(result);
        }


        /// <summary>
        /// Retrieves a list of articles liked by a specified user.
        /// </summary>
        /// <param name="userId">The unique identifier of the user.</param>
        /// <returns>A like response containing a list of articles the user has liked, if any; otherwise, an error response.</returns>
        [HttpGet("/User/{userId}/Likes")]
        [ProducesResponseType(typeof(ApiResponse<List<UserLikesResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserLikes([FromRoute] int userId)
        {
            var query = new GetUserLikesQuery { UserId = userId };
            var result = await _mediatr.Send(query);

            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }
    }
}
