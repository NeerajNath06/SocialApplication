using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialApplication.Domain.Model;

namespace SocialApplication.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPostById(int id)
        {
            // Simulate fetching a post from a database
            var post = new Post
            {
                Id = id,
                Content = "This is a sample post content 2."
            };
            return Ok(post);
        }
    }
}
