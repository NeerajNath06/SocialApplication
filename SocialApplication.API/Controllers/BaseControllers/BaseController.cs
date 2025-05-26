using Microsoft.AspNetCore.Mvc;
using SocialApplication.API.Contracts.Comman;
using SocialApplication.Application.Enums;
using SocialApplication.Application.ErrorModels;

namespace SocialApplication.API.Controllers.BaseControllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult HandeErrorResponse(List<Error> errors)
        {
            if (errors.Any(e => e.ErrorCodes == ErrorCode.NotFound))
            {
                var error = errors.FirstOrDefault(e => e.ErrorCodes == ErrorCode.NotFound);
                var apiError = new ErrorResponse();
                apiError.StatusCode = (int)ErrorCode.NotFound;
                apiError.StatusPhrase = $"User Not Found.";
                apiError.Timestamp = DateTime.UtcNow;
                apiError.Errors.Add(error.ErrorMessage);
                return NotFound(apiError);
            }
            else
            {
                var error = errors.FirstOrDefault(e => e.ErrorCodes == ErrorCode.InternalServerError);
                var apiError = new ErrorResponse();
                apiError.StatusCode = (int)ErrorCode.InternalServerError;
                apiError.StatusPhrase = $"Internal Server Error.";
                apiError.Timestamp = DateTime.UtcNow;
                apiError.Errors.Add(error.ErrorMessage);
                return StatusCode(500, apiError);
            }
        }
    }
}
