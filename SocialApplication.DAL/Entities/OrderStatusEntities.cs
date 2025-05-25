using SocialApplication.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.DAL.Entities
{
    public class OrderStatusEntities
    {
        public OrderStatus OrderStatusId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
