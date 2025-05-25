using SocialApplication.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public OrderStatus OrderStatusId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }
        public int PaymentMethodId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Address ShippingAddress { get; set; }
        public virtual OrderStatusEntities OrderStatus { get; set; }
        public Address BillingAddress { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public ICollection<OrderStatusHistory> StatusHistory { get; set; }
    }
}
