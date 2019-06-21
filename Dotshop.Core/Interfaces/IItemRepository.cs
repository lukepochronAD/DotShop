using System.Collections.Generic;
using System.Threading.Tasks;
using Dotshop.Core.Models;

namespace Dotshop.Core.Interfaces
{
    public interface IItemRepository
    {

        Task<IEnumerable<Item>> GetAllItems();

        Task<Item> CreateNew(Item item);

        Task<Item> GetById(int id);

        Task<bool> Delete(int id);
    }
}
