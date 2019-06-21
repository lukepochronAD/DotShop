using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dotshop.Core.Models;

namespace Dotshop.Core.Interfaces
{
    public interface IItemRepository
    {

        Task<IEnumerable<Item>> GetAllItems();
            
    }
}
