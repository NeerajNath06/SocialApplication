using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.DAL.Enums
{
    public enum PaymentType
    {
        [Description("Unknown payment type. This is the default value and indicates that the payment type is not specified.")]
        CreditCard = 1,
        [Description("Payment made using a debit card.")]
        DebitCard = 2,
        [Description("Payment made using a digital wallet service.")]
        PayPal = 3,
        [Description("Payment made using a bank transfer.")]
        BankTransfer = 4,
        [Description("Payment made using cash on delivery.")]
        CashOnDelivery = 5
    }
}
