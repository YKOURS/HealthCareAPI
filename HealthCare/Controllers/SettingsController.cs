using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : BaseController
    {
        [HttpGet(nameof(GetDashBoard))]
        public IActionResult GetDashBoard()
        {
            return Ok("Working OnIt");
        }
    }
}
