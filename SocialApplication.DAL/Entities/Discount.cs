using SocialApplication.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.DAL.Entities
{
    public class Discount
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DiscountType DiscountTypeId { get; set; }
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double? MinimumOrderAmount { get; set; }
        public int? MaximumUses { get; set; }
        public int CurrentUses { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public ICollection<Order> Orders { get; set; }
        public virtual DiscountTypeEntities DiscountType { get; set; }
    }
}
