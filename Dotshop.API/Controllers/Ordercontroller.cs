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
            var result = await((this.OrderRepository.GetById(id)));
            if(result == null)
            {
                return NotFound();
            }
            return this.Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> CreateNew(Order order)
        {
            var result = await (this.OrderRepository.CreateNew(order));

            return this.CreatedAtAction(nameof(GetById), new { id = result.OrderId }, result);

        }
    }
}

