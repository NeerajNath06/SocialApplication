

namespace SocialApplication.API.Controllers.ApiController
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.Extensions.Primitives;
    using SocialApplication.Application.Exceptions;
    using SocialApplication.Application.Guards;
    using SocialApplication.Application.Utilities;
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Net;
    using System.Net.Http.Headers;

    [ApiController]
    [ExcludeFromCodeCoverage]
    public class ApiController : Controller
    {
        // <summary>
        // The ApiController class is a base controller for the API, inheriting from the ASP.NET Core Controller class.
        // It provides a common base for all API controllers in the application.
        // </summary>

        // <remarks>
        // The ApiController class is decorated with the [ApiController] attribute, which enables API-specific behavior
        // such as automatic model validation and response formatting.
        // The [ExcludeFromCodeCoverage] attribute is used to exclude this class from code coverage analysis.
        // </remarks>

        private const string HeaderNameToken = "Authorization";

        private readonly ILogger _logger;

        private IMediator _mediator;

        public string AcceptLanguage { get; private set; }

        public CultureInfo Culture { get; private set; }

        // <summary>
        // Gets the Mediator instance used for handling requests.
        // </summary>
        // <returns>The Mediator instance.</returns>
        protected IMediator Mediator
        {
            get
            {
                _mediator = HttpContext.RequestServices.GetService(typeof(IMediator)) as IMediator;
                if (_mediator == null)
                {
                    throw new InvalidOperationException("Mediator is not initialized.");
                }
                return _mediator!; // Use the null-forgiving operator to suppress the warning.  
            }
        }

        // <summary>
        // get the Bearer token from the request headers.
        // </summary>

        protected string BearerToken => base.HttpContext.Request.Headers.FirstOrDefault<KeyValuePair<string, StringValues>>((KeyValuePair<string, StringValues> f) => f.Key == "Authorization").Value.FirstOrDefault();

        // <summary>
        // Get the language header from the request.
        // </summary>
        protected string LanguageHeader
        {
            get
            {
                if (Request == null || !Request.GetTypedHeaders().AcceptLanguage.Any())
                {
                    return "en-US";
                }

                return Request.GetTypedHeaders().AcceptLanguage.OrderByDescending((StringWithQualityHeaderValue) => StringWithQualityHeaderValue.Quality.GetValueOrDefault(1.0)).SingleOrDefault().Value.Value;
            }
        }

        // <summary>
        // Gets the current request's headers.
        // </summary>
        public new HttpRequest Request => base.HttpContext?.Request;

        // <summary>
        // Gets the current request's response.
        // </summary>
        public new HttpResponse Response => base.HttpContext?.Response;

        // <summary>
        // Gets the Microsoft.AspNetCore.Mvc.Routing.Raoutdata for the current request.
        public new RouteData RouteData => base.ControllerContext.RouteData;

        // <summary>
        // Gets the Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary for the current request.
        // </summary>
        public ModelStateDictionary ModelState => base.ControllerContext.ModelState;

        // <summary>
        // Initializes a new instance of the ApiController class.
        // </summary>
        public ApiController()
        {

        }

        // <summary>
        // Initializes a new instance of the ApiController class with the specified logger.
        // </summary>
        /// <param name="logger">The logger instance to use for logging.</param>
        public ApiController(ILogger logger)
        {
            _logger = logger;
        }

        // <summary>
        // Create Microsoft.AspNetCore.Mvc.ActionResult for the current response.
        [NonAction]
        public override AcceptedResult Accepted()
        {
            return new AcceptedResult();
        }

        [NonAction]
        public AcceptedResult Accepted<T>(string location, T value)
        {
            return new AcceptedResult(location, CreateResponseModel(value));
        }

        private ResponseModel<T> CreateResponseModel<T>(T elements)
        {

            if (typeof(T).GetInterfaces().Any((Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
            {
                int numberOfElements = ((IEnumerable)(object)elements).Cast<object>().Count();
                return new ResponseModel<T>
                {
                    Elements = elements,
                    NumberOfElements = numberOfElements,
                };
            }
            return new ResponseModel<T>
            {
                Elements = elements,
                NumberOfElements = 1,
            };
        }

        [NonAction]
        public AcceptedResult Accepted<T>(Uri uri, T value)
        {
            return new AcceptedResult(uri.AgainsNull(), CreateResponseModel(value));
        }

        [NonAction]
        public AcceptedAtRouteResult AcceptedAtRoute<T>(string routeName, object routeValues, T value)
        {
            return new AcceptedAtRouteResult(routeName, routeValues, CreateResponseModel(value));
        }

        [NonAction]
        public BadRequestObjectResult BadRequest(IEnumerable<string> messages)
        {
            _logger.LogError(string.Join("\r\n", messages.Select((string v) => v ?? ""), base.HttpContext.Request.Method), "BadRequest", "ApiController Call.");
            return new BadRequestObjectResult(CreateResponseModel(messages));
        }

        [NonAction]
        protected IActionResult Ok<T>([NotNull] T value)
        {
            return base.Ok(CreateResponseModel(value));
        }

        [NonAction]
        public override NotFoundResult NotFound()
        {
            return new NotFoundResult();
        }

        [NonAction]
        public IActionResult NotFound<T>(T value, string message) where T : Exception
        {
            T val = value.AgainsNull("NotFoud");
            string messsage2 = message.AgainstEmpty("NotFound");
            Guid errorId = Guid.NewGuid();

            _logger.LogError(val.Message, base.HttpContext.Request.Method, "NotFound", "ApiController Call.");
            return StatusCode(410, new ErrorModel<T>
            {
                Message = messsage2,
                ErrorId = errorId,
            });
        }

        [NonAction]
        public IActionResult Gone(string message, Exception value)
        {
            Exception ex = value.AgainsNull("Gone");
            string messsage2 = message.AgainstEmpty("Gone");
            Guid errorId = Guid.NewGuid();
            _logger.LogError(ex.Message, errorId, base.HttpContext.Request.Method, "Gone", "ApiController Call.");

            return StatusCode(410, new ErrorModel<Exception>
            {
                Message = messsage2,
                ErrorId = errorId,
            });
        }

        [NonAction]
        public IActionResult Gone(string message)
        {
            string messsage2 = message.AgainstEmpty("Gone");
            Guid errorId = Guid.NewGuid();
            _logger.LogError(messsage2, errorId, base.HttpContext.Request.Method, "Gone", "ApiController Call.");

            return StatusCode(410, new ErrorModel<Exception>
            {
                Message = messsage2,
                ErrorId = errorId,
            });
        }

        [NonAction]
        public IActionResult Gone(Exception value)
        {
            Exception ex = value.AgainsNull("Gone");
            Guid errorId = Guid.NewGuid();
            _logger.LogError(ex.Message, errorId, base.HttpContext.Request.Method, "Gone", "ApiController Call.");

            return StatusCode(410, new ErrorModel<Exception>
            {
                Message = ex.Message,
                ErrorId = errorId,
            });
        }

        [NonAction]
        public IActionResult Gone()
        {
            _logger.LogError(string.Empty, base.HttpContext.Request.Method, "Gone", "ApiController Call.");
            return StatusCode(410, new ErrorModel<Exception>
            {
                Message = string.Empty,
                ErrorId = Guid.NewGuid(),
            });
        }

        [NonAction]
        public async Task<IActionResult> ApiErrorAsync<T>([NotNull] T value, int statusCode) where T : ApiException
        {
            ErrorModel<Exception> errorModel = await value.GetContentAsAsync<ErrorModel<Exception>>().ConfigureAwait(continueOnCapturedContext: false);
            _logger.LogError(errorModel.Message, errorModel.ErrorId, base.HttpContext.Request.Method, "ApiError", "ApiController Call.");
            return StatusCode(statusCode, new ErrorModel<T>
            {
                StatusCode = (HttpStatusCode)statusCode,
                Message = errorModel.Message,
                ErrorId = errorModel.ErrorId,
            });
        }

        [NonAction]
        public async Task<IActionResult> ApiErrorAsync<T>([NotNull] T value) where T : ApiException
        {
            T variable = value.AgainsNull("ApiError");
            ErrorModel<Exception> errorModel = await variable.GetContentAsAsync<ErrorModel<Exception>>().ConfigureAwait(continueOnCapturedContext: false);
            Guid errorId = Guid.NewGuid();
            if (errorModel == null)
            {
                _logger.LogError(errorModel.Message, errorModel.ErrorId, base.HttpContext.Request.Method, "An error occurred while processing your request.", "ApiController Call.");
                return StatusCode((int)variable.StatusCode, new ErrorModel<T>
                {
                    Message = variable.Message,
                    ErrorId = errorId,
                    StatusCode = variable.StatusCode
                });
            }

            _logger.LogError(errorModel.Message, errorModel.ErrorId, base.HttpContext.Request.Method, "An error occurred while processing your request.", "ApiController Call.");
            return StatusCode((int)variable.StatusCode, new ErrorModel<T>
            {
                Message = variable.Message,
                ErrorId = errorModel.ErrorId,
                StatusCode = variable.StatusCode
            });
        }

        [NonAction]
        public IActionResult Error<T>([NotNull] T value) where T : Exception
        {
            T val = value.AgainsNull("Error");
            Guid errorId = Guid.NewGuid();
            HttpStatusCode statusCode = HttpStatusCode.NoContent;
            if(!(value is ArgumentException))
            {
                if (!(value is NullReferenceException))
                {
                    if (!(value is IndexOutOfRangeException && !(value is FormatException)))
                    {
                        if (value is ApiException)
                        {
                            ((ApiException)(object)val).RequestMessage.Headers.Authorization = null;
                            statusCode = HttpStatusCode.InternalServerError;
                        }
                        else
                        {
                            statusCode = HttpStatusCode.InternalServerError;
                        }
                    }
                    else
                    {
                        statusCode = HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    statusCode = HttpStatusCode.InternalServerError;
                }
            }
            _logger.LogError(val.Message, errorId, base.HttpContext.Request.Method, "An error occurred while processing your request.", "ApiController Call.");
            return StatusCode((int)statusCode, new ErrorModel<T>
            {
                Message = val.Message,
                ErrorId = errorId,
                StatusCode = statusCode
            });
        }
    }
}
