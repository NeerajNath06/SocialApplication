using SocialApplication.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.DAL.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public PaymentType PaymentTypeId { get; set; }
        public string Provider { get; set; }
        public string AccountNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsDefault { get; set; }
        public int UserId { get; set; }

        // Navigation property
        public User User { get; set; }
        public virtual PaymentTypeEntities PaymentType { get; set; }
    }
}
