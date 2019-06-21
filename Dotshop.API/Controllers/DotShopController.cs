using Dotshop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dotshop.API.Controllers
{
    [Route("api")]
    [ApiController]

    public class DotshopController : Controller
    {
        private IItemRepository ItemRepository { get; }
        private IOrderRepository OrderRepository { get; }
        public DotshopController (IItemRepository _itemrepository, IOrderRepository _orderRepository)
        {
            this.ItemRepository = _itemrepository;
            this.OrderRepository = _orderRepository;
        }


        [HttpGet("items")]
        public IActionResult GetAllItems()
        {
            
            return this.Ok (this.ItemRepository.GetAllItems().Result);
        }

        [HttpGet("orders")]
        public IActionResult GetAllOrders()
        {

            return this.Ok(this.OrderRepository.GetAllOrders().Result);
        }

        [HttpGet("orders/{id}")]
        public IActionResult GetById(int id)
        {
           return this.Ok(this.OrderRepository.GetById(id).Result);

        }
    }
}

