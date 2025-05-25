using SocialApplication.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.DAL.Entities
{
    public class OrderStatusHistory
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime StatusDate { get; set; } = DateTime.UtcNow;
        public string Notes { get; set; }
        public int OrderId { get; set; }

        // Navigation property
        public Order Order { get; set; }
    }
}
