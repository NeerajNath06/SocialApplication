

namespace SocialApplication.API.Controllers.V1
{
    using Microsoft.AspNetCore.Mvc;
    using SocialApplication.API.ApiRoutes;


    [ApiVersion("1.0")]
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
