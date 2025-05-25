using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.DAL.Enums
{
    public enum AddressType
    {
        // Enum values for different types of addresses
        // 0 is reserved for Unknown, which is a common practice in enums to represent an uninitialized state
        /// <summary>
        ///     
        [Description("Unknown address type. This is the default value and indicates that the address type is not specified.")]
        Unknown = 0,
        [Description("Home address. Typically used for personal residences.")]
        Home = 1,
        [Description("Work address. Typically used for business or professional locations.")]
        Shipping = 2,
        [Description("Billing address. Typically used for financial transactions or invoicing purposes.")]
        Billing = 3,
        [Description("Both home and work address. This can be used when an address serves dual purposes or when both types are applicable.")]
        Both = 4
    }
}
