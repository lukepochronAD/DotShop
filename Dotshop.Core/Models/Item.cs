using System.ComponentModel.DataAnnotations;

namespace Dotshop.Core.Models
{
    public class Item
    {
        // dbo.Items

        public int ItemId { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public string ItemDescription { get; set; }

        [Required]
        public double ItemPrice { get; set; }

    }
}