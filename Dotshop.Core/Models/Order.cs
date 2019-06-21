using System;
using System.Collections.Generic;
using System.Text;

namespace Dotshop.Core.Models
{
    public class Order
    {
        int OrderId { get; set; }
        DateTime OrderDate { get; set; }
        byte OrderPaid { get; set; }
        // dbo.Orders
    }
}