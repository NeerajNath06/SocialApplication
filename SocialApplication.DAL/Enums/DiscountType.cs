using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.DAL.Enums
{
    public enum DiscountType
    {
        [Description("Percentage")]
        Percentage=1,
        [Description("FixedAmount")]
        FixedAmount =2,
        [Description("FreeShipping")]
        FreeShipping =3,
    }
}
