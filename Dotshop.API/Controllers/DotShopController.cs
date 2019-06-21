using System.Threading.Tasks;
using Dotshop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dotshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DotshopController : Controller
    {
        private IItemRepository itemrepository;
        private IOrderRepository orderrepository;
        public DotshopController (IItemRepository _itemrepository, IOrderRepository _orderRepository)
        {
            this.itemrepository = _itemrepository;
            this.orderrepository = _orderRepository;
        }


        [HttpGet("items")]
        public IActionResult GetAllItems()
        {
            
            return Ok (this.itemrepository.GetAllItems().Result);
        }

        [HttpGet("orders")]
        public IActionResult GetAllOrders()
        {

            return Ok(this.orderrepository.GetAllOrders().Result);
        }
    }
}

