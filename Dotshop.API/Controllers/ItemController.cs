using System.Threading.Tasks;
using Dotshop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dotshop.API.Controllers
{
    [Route("api/items")]
    [ApiController]

    public class ItemController : Controller
    {
        private IItemRepository ItemRepository { get; }
        public ItemController(IItemRepository _itemrepository)
        {
            this.ItemRepository = _itemrepository;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var result = await (this.ItemRepository.GetAllItems());

            return this.Ok(result);


            }



    }
}

