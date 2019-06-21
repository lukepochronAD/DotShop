using System;
using System.Collections.Generic;
using System.Text;

namespace Dotshop.Core.Models
{
    public class Item
    {
        // dbo.Items

        int Id { get; set; }
        string ItemName { get; set; }
        string ItemDescription { get; set; }
        float Price { get; set; }

    }
}