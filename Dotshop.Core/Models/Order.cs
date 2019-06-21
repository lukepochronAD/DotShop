using System;

namespace Dotshop.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderPaid { get; set; }
        public double TotalDue { get; set; }
        // dbo.Orders
    }
}