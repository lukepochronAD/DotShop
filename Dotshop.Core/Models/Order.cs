using System;
using System.ComponentModel.DataAnnotations;

namespace Dotshop.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public bool OrderPaid { get; set; }

        public double TotalDue { get; set; }
    }
}