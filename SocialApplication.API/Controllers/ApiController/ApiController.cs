using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;
using SocialApplication.Application.ErrorModels;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Http.Headers;

namespace SocialApplication.API.Controllers.ApiController
{
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

        protected string BearerToken=>base.HttpContext.Request.Headers.FirstOrDefault<KeyValuePair<string, StringValues>>((KeyValuePair<string, StringValues> f) =>f.Key == "Authorization").Value.FirstOrDefault();

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

           if(typeof(T).GetInterfaces().Any((Type t)=>t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
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
    }
}
