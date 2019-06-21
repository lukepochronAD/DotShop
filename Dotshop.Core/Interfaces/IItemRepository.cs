using System;
using System.Collections.Generic;
using System.Text;
using Dotshop.Core.Models;

namespace Dotshop.Core.Interfaces
{
    public interface IItemRepository
    {

        IEnumerable<Item> GetAllItems();
            
    }
}
