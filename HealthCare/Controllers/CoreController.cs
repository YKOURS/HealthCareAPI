using HealthCare.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class CoreController : BaseController
    {
        private readonly CoreService _core;
        public CoreController(CoreService core)
        {
            _core = core;
        }

        /// <summary>
        /// GetLookUp
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>

        [HttpGet(nameof(GetLookUp))]
        public IActionResult GetLookUp(string Type)
        {
            var result = _core.GetLookUp(Type);

            return Ok(result);
        }

    }
}
