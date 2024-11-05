using Norebase_Like_Feature_Challenge.Domain.Common;
using Norebase_Like_Feature_Challenge.Domain.Interfaces;
using MediatR;

namespace Norebase_Like_Feature_Challenge.Application.Features.Users
{
    public class AddUserCommand : IRequest<ApiResponse<AddUserResponse>>
    {
        public string Name { get; set; }
    }

    public class AddUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, ApiResponse<AddUserResponse>>
    {
        private readonly IUserService _userService;

        public AddUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ApiResponse<AddUserResponse>> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            var newUser = await _userService.AddUserAsync(command.Name);

            return new ApiResponse<AddUserResponse>
            {
                Data = new AddUserResponse { Id = newUser.Id, Name = newUser.Name },
                IsSuccessful = true,
                StatusCode = "00",
                Message = $"User {newUser.Name} successfully created."
            };
        }
    }

}
