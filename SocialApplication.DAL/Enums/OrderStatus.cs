using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.DAL.Enums
{
    public enum OrderStatus
    {
        // Enum values for different order statuses
        // 0 is reserved for Unknown, which is a common practice in enums to represent an uninitialized state
        [Description("Unknown order status. This is the default value and indicates that the order status is not specified.")]
        Unknown = 0,
        [Description("Order is pending. This status indicates that the order has been placed but not yet processed.")]
        Pending = 1,
        [Description("Order is being processed. This status indicates that the order is currently being prepared or handled by the system.")]
        Processing = 2,
        [Description("Order has been shipped. This status indicates that the order has been dispatched and is on its way to the customer.")]
        Shipped = 3,
        [Description("Order has been delivered. This status indicates that the order has reached the customer successfully.")]
        Delivered = 4,
        [Description("Order has been cancelled. This status indicates that the order was cancelled before it could be processed or shipped.")]
        Cancelled = 5,
        [Description("Order has been refunded. This status indicates that the order was returned or the payment was reversed, and the customer has been refunded.")]
        Refunded = 6,
    }
}
