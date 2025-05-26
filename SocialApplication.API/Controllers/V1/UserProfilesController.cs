

namespace SocialApplication.API.Controllers.V1
{
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using SocialApplication.API.ApiRoutes;
    using SocialApplication.API.Contracts.Comman;
    using SocialApplication.API.Contracts.UserProfiles.Requests;
    using SocialApplication.API.Contracts.UserProfiles.Responcses;
    using SocialApplication.Application.Commands.UserProfiles;
    using SocialApplication.Application.Enums;
    using SocialApplication.Application.Queries.UserProfiles;

    [ApiVersion("1.0")]
    [Route(ApiRoute.BaseRoute)]
    [ApiController]
    public class UserProfilesController : BaseControllers.BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserProfilesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route(ApiRoute.UserProfiles.GetAll)]
        public async Task<IActionResult> GetAllUserProfileByIdAsync()
        {
            var query = new GetAllUserProfilesQuery();
            var result = await _mediator.Send(query);
            var response = _mapper.Map<List<UserProfileDto>>(result);
            // Simulate fetching user profile by ID  
            return Ok(response);
        }

        [HttpPost]
        [Route(ApiRoute.UserProfiles.Create)]
        public async Task<IActionResult> CreateUserProfileAsync([FromBody] AddUpdateUserProfile addUserProfile)
        {
            // Simulate fetching user posts by user ID  
            var command = _mapper.Map<AddUserProfileCommand>(addUserProfile);
            var result = await _mediator.Send(command);
            var response = _mapper.Map<UserProfileDto>(result);
            return Ok(response);
        }

        [HttpGet]
        [Route(ApiRoute.UserProfiles.IdRoute)]
        public async Task<IActionResult> GetUserProfileByIdAsync(string id)
        {
            var query = new GetUserProfileByIdQuery { ProfileId = Guid.Parse(id) };
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound($"No User Associate with this {id} Id.");
            }
            var response = _mapper.Map<UserProfileDto>(result);
            // Simulate fetching user profile by ID  
            return Ok(response);
        }

        [HttpPatch]
        [Route(ApiRoute.UserProfiles.IdRoute)]
        public async Task<IActionResult> UpdateUserProfileByIdAsync(string id, AddUpdateUserProfile updateUserProfile)
        {
            var command = _mapper.Map<UpdateUserProfileByIdCommand>(updateUserProfile);
            command.ProfileId = Guid.Parse(id);
            var result = await _mediator.Send(command);
            // Simulate fetching user profile by ID
            if (result.IsError) HandeErrorResponse(result.Errors);

            //var response = _mapper.Map<UserProfileDto>(result.Payload);
            return Ok(result);
        }

        [HttpDelete]
        [Route(ApiRoute.UserProfiles.IdRoute)]
        public async Task<IActionResult> DeleteUserProfileByIdAsync(string id, DeleteUserProfileCommand deleteUserProfile)
        {
            var command = new DeleteUserProfileCommand();
            command.ProfileId = Guid.Parse(id);
            await _mediator.Send(command);
            // Simulate fetching user profile by ID  
            return NoContent();
        }
    }
}
