using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialApplication.Domain.Model;

namespace SocialApplication.API.Controllers.V2
{
    [ApiVersion("2.0")]
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
                Content = "This is a sample post content."
            };
            return Ok(post);
        }
    }
}
