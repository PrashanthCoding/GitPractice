namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        // POST api/data
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok($"Received value: {value}");
        }
    }
}
