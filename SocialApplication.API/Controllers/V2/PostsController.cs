using Microsoft.AspNetCore.Mvc;
using SocialApplication.API.ApiRoutes;

namespace SocialApplication.API.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route(ApiRoute.BaseRoute)]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        [Route(ApiRoute.Posts.GetById)]
        public IActionResult GetPostById(int id)
        {
            return Ok();
        }
    }
}
