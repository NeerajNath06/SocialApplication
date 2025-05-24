

namespace SocialApplication.API.Controllers.ApiController.BaseController
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using NSwag.Annotations;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public abstract class GenericBaseController<T> : ApiControllerBase
        where T : class, new()
    {
        protected GenericBaseController(ILogger logger, IMediator mediator) : base(logger, mediator)
        {
        }

        [HttpPost]
        [Route("create")]
        [OpenApiOperation("Create", "Creates a new resource of type T.")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(UnauthorizedAccessException), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(HttpRequestException), (int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]

        public async Task<IActionResult> CreateNewEntityAsync([FromBody] T entity, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
