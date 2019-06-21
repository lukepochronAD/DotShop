using System.Threading.Tasks;
using Dotshop.Core.Interfaces;
using Dotshop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dotshop.API.Controllers
{
    [Route("api/orders")]
    [ApiController]

    public class OrderController : Controller
    {

        public OrderController(IOrderRepository _orderRepository)
        {
            this.OrderRepository = _orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew(Order order)
        {
            var result = await (this.OrderRepository.CreateNew(order));

            return this.CreatedAtAction(nameof(GetById), new { id = result.OrderId }, result);

        }

        private IOrderRepository OrderRepository { get; }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await (this.OrderRepository.GetAllOrders());
            return this.Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await ((this.OrderRepository.GetById(id)));
            if (result == null)
            {
                return this.NotFound();
            }
            return this.Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> ChangePaidStatus([FromBody] Order order, bool paid)
        {
            var result = await (this.OrderRepository.ChangeStatus(order, paid));

            if (result == false)
            {
                return this.NotFound();
            }
            return this.Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await (this.OrderRepository.Delete(id));

            if (result == false)
            {
                return this.NotFound();
            }
            return this.Ok(result);
        }

    }
}