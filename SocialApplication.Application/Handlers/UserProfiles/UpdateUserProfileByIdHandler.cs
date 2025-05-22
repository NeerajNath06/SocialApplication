

namespace SocialApplication.Application.Handlers.UserProfiles
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using SocialApplication.Application.Commands.UserProfiles;
    using SocialApplication.Application.Enums;
    using SocialApplication.Application.ErrorModels;
    using SocialApplication.DAL.DataContext;
    using SocialApplication.Domain.Aggregates.UserProfiles;
    using System;
    using System.Threading.Tasks;
    internal class UpdateUserProfileByIdHandler : IRequestHandler<UpdateUserProfileByIdCommand, OperationsResult<UserProfile>>
    {
        private readonly SocialApplicationDbContext _dbContext;
        public UpdateUserProfileByIdHandler(SocialApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OperationsResult<UserProfile>> Handle(UpdateUserProfileByIdCommand request, CancellationToken cancellationToken)
        {
            // Implementation for updating a user profile by ID
            var operationsResult = new OperationsResult<UserProfile>();
            var errors = new Error();
            try
            {
                // Check if the user profile exists
                var userProfile = await _dbContext.UserProfiles
                .FirstOrDefaultAsync(up => up.UserId == request.ProfileId, cancellationToken);

                // If the user profile does not exist, return an error
                if (userProfile == null)
                {
                    errors = new Error { ErrorCodes = ErrorCode.NotFound, ErrorMessage = $"User profile with ID {request.ProfileId} not found." };
                    operationsResult.IsError = true;
                    operationsResult.Errors.Add(errors);
                    return operationsResult;
                }
                // Update the user profile with the new information
                var userInfo = UserInfo.CreateUserInfo(
                    request.FirstName,
                    request.LastName,
                    request.EmailAddress,
                    request.PhoneNumber,
                    request.Address,
                    request.CurrentCity,
                    request.DateOfBirth
                );
                // Check if the userInfo is valid
                // Update the user profile with the new information
                userProfile.UpdateUserInfo(userInfo);
                _dbContext.UserProfiles.Update(userProfile);
                await _dbContext.SaveChangesAsync(cancellationToken);
                operationsResult.Payload = userProfile;
                operationsResult.ErrorId = new Guid("0000-0000-0000-0000");
                operationsResult.IsSuccess = true;
            }
            // Handle any validation errors that occur during the update process
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency errors
                errors = new Error { ErrorCodes = ErrorCode.ConcurrencyError, ErrorMessage = "Concurrency error occurred while updating the user profile." };
                operationsResult.IsError = true;
                operationsResult.Errors.Add(errors);
            }
            catch (Exception ex)
            {
                errors = new Error { ErrorCodes = ErrorCode.InternalServerError, ErrorMessage = ex.Message };
                // Handle any exceptions that occur during the update process
                operationsResult.IsError = true;
                operationsResult.Errors.Add(errors);
            }
            return operationsResult;
        }
    }
}
