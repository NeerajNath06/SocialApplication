

namespace SocialApplication.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Post
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        //public int UserId { get; set; }
        //public int LikesCount { get; set; }
        //public int CommentsCount { get; set; }
        //// Navigation properties
        //public virtual User User { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
