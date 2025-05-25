using SocialApplication.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.DAL.Entities
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool IsDefault { get; set; }
        public AddressType AddressTypeId { get; set; }
        public int UserId { get; set; }

        // Navigation property
        public User User { get; set; }
        public virtual AddressTypeEntities AddressType { get; set; }
    }
}
