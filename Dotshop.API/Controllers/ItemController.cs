using System.Threading.Tasks;
using Dotshop.Core.Interfaces;
using Dotshop.Core.Models;
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

        [HttpGet("{id}")] // That's for CreatedAtAction confirmation
        public async Task<IActionResult> GetById(int id)
        {
            var result = await ((this.ItemRepository.GetById(id)));
            if (result == null)
            {
                return this.NotFound();
            }
            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(Item newitem)
        {
            var result = await (this.ItemRepository.CreateNew(newitem));

            return this.CreatedAtAction(nameof(GetById), new { id = result.ItemId }, result);
        }



    }
}

