using System.Collections.Generic;
using System.Linq;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaginatedItemsController : ControllerBase
    {
        private static List<string> items = Enumerable.Range(1, 100).Select(x => $"Item {x}").ToList();

        // GET api/paginateditems?page=2&pageSize=10
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(int page = 1, int pageSize = 10)
        {
            var paginatedItems = items.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(paginatedItems);
        }
    }
}
