using System.Collections.Generic;
using System.Threading.Tasks;
using Dotshop.Core.Models;

namespace Dotshop.Core.Interfaces
{
    public interface IOrderRepository
    {

        Task<IEnumerable<Order>> GetAllOrders();

        Task<Order> GetById(int id);

        Task<Order> CreateNew(Order order);

        //Task<Order> ChangeStatus(int id, byte status);




    }
}
