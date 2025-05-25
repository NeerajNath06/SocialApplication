using SocialApplication.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.DAL.Entities
{
    public class AddressTypeEntities
    {
        public AddressType AddressTypeId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
