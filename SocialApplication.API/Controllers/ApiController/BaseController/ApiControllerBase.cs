
namespace SocialApplication.API.Controllers.ApiController.BaseController
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SocialApplication.Application.Exceptions;
    using SocialApplication.Application.Guards;
    using SocialApplication.Application.Utilities;
    using SocialApplication.Domain.Models.Exceptions;
    using SocialApplication.Domain.Models.Exceptions.Shared;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ApiController
    {

        protected readonly ILogger _logger;
        protected readonly IMediator _mediator;

        public ApiControllerBase(ILogger logger, IMediator mediator)
        {
            _logger = logger.AgainsNull();
            _mediator = mediator.AgainsNull();
        }

        /// <summary>
        /// 
        /// </summary>

        /// <returns></returns>
        public async Task<IActionResult> CreateActionResult<TResponse>(IRequest<TResponse> request, CancellationToken token)
        {
            try
            {
                var response = await _mediator.Send(request, token);
                return Ok(response);
            }
            catch (ApiException createApiException)
            {
                _logger.LogError(createApiException, "An error occurred while processing the request: {Message}", createApiException.Message);
                return await ApiErrorAsync(createApiException);
            }
            catch (AppException appException)
            {
                _logger.LogError(appException, "An application error occurred: {Message}", appException.Message);
                return CustomErrorAsync(appException);
            }
            catch (AppValidationException appValidatonException)
            {
                _logger.LogError(appValidatonException, "An application error occurred: {Message}", appValidatonException.Message);
                return CustomErrorAppValidationAsync(appValidatonException);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "An unexpected error occurred: {Message}", exception.Message);
                return Error(exception);
            }
        }


        /// <summary>
        /// 
        /// </summary>

        /// <returns></returns>
        public async Task<IActionResult> OkActionResult<TResponse>(IRequest<TResponse> request, CancellationToken token)
        {
            try
            {
                var response = await _mediator.Send(request, token);
                return Ok(response);
            }
            catch (ApiException createApiException)
            {
                _logger.LogError(createApiException, "An error occurred while processing the request: {Message}", createApiException.Message);
                return await ApiErrorAsync(createApiException);
            }
            catch (AppException appException)
            {
                _logger.LogError(appException, "An application error occurred: {Message}", appException.Message);
                return CustomErrorAsync(appException);
            }
            catch (AppValidationException appValidatonException)
            {
                _logger.LogError(appValidatonException, "An application error occurred: {Message}", appValidatonException.Message);
                return CustomErrorAppValidationAsync(appValidatonException);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "An unexpected error occurred: {Message}", exception.Message);
                return Error(exception);
            }
        }

        [NonAction]
        public IActionResult CustomErrorAsync(AppException exception)
        {
            var value = exception.AgainsNull();
            var errorId = Guid.NewGuid();
            var statusCode = HttpStatusCode.InternalServerError;
            _logger.LogError(value.Message, errorId, HttpContext.Request.Method);

            return StatusCode((int)statusCode, new ErrorModel<AppException>
            {
                ErrorId = errorId,
                Message = value.Message,
                StatusCode = statusCode
            });
        }

        [NonAction]
        public IActionResult CustomErrorAppValidationAsync(AppValidationException exception)
        {
            var value = exception.AgainsNull();
            var errorId = Guid.NewGuid();
            _logger.LogError(value.Message, errorId, HttpContext.Request.Method);

            return StatusCode((int)HttpStatusCode.BadRequest, new ResponseModel<ValidationErrorResponseModelElement>
            {
                Elements = value.ResponseModelElement,
                Message = value.Message
            });
        }
    }
}
