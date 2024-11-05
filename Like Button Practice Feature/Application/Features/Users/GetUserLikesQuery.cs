using Norebase_Like_Feature_Challenge.Domain.Common;
using Norebase_Like_Feature_Challenge.Domain.Interfaces;
using Norebase_Like_Feature_Challenge.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Norebase_Like_Feature_Challenge.Application.Features.Users
{
    public class GetUserLikesQuery : IRequest<ApiResponse<List<UserLikesResponse>>>
    {
        public int UserId { get; set; }
    }

    public class UserLikesResponse
    {
        public string Title { get; set; }
        public DateTime LikedAt { get; set; }
    }

    public class GetUserLikesQueryHandler : IRequestHandler<GetUserLikesQuery, ApiResponse<List<UserLikesResponse>>>
    {
        private readonly ILikeService _likeService;
        private readonly ApplicationDbContext _context;

        public GetUserLikesQueryHandler(ILikeService likeService, ApplicationDbContext context)
        {
            _likeService = likeService;
            _context = context;
        }

        public async Task<ApiResponse<List<UserLikesResponse>>> Handle(GetUserLikesQuery query, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == query.UserId);
            if (user == null)
                return new ApiResponse<List<UserLikesResponse>> { IsSuccessful = false, StatusCode = "01", Message = $"No user found for user id {query.UserId}" };

            var response = await _likeService.GetUserLikesAsync(query.UserId);

            if (response.Count == 0)
                return new ApiResponse<List<UserLikesResponse>> { IsSuccessful = true, StatusCode = "00", Message = $"No likes found for {user.Name}" };

            return new ApiResponse<List<UserLikesResponse>> { Data = response, IsSuccessful = true, StatusCode = "00", Message = $"{user.Name}'s likes successfully retrieved" };
        }
    }

}
