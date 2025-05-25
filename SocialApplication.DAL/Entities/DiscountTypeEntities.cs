using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApplication.DAL.Enums;

namespace SocialApplication.DAL.Entities
{
    public class DiscountTypeEntities
    {
        public DiscountType DiscountTypeId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();
    }
}
