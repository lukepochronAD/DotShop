using Microsoft.AspNetCore.Mvc;

namespace Dotshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DotshopController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            return this.Ok("hello wurld");
        }
    }
}
