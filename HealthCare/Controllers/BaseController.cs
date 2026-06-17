using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Health")]
    public class BaseController : ControllerBase
    {

    }
}


