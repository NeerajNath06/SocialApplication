using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.DAL.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDefault { get; set; }
        public int ProductId { get; set; }

        // Navigation property
        public Product Product { get; set; }
    }
}
