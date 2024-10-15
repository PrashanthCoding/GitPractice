using System.Threading.Tasks;

namespace MasterDataServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationMasterController : ControllerBase
    {
        private readonly MasterDataContext _context;

        public LocationMasterController(MasterDataContext context)
        {
            _context = context;
        }

        // POST api/locationmaster
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LocationMaster locationMaster)
        {
            if (ModelState.IsValid)
            {
                _context.LocationMasters.Add(locationMaster);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "LocationMaster data saved successfully!" });
            }

            return BadRequest(ModelState); // If model validation fails
        }
    }
}
