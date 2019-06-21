namespace Dotshop.Core.Models
{
    public class Item
    {
        // dbo.Items

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public double ItemPrice { get; set; }

    }
}