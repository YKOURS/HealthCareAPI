using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class SettingsController : BaseController
    {
        public SettingsController() {
            
        }

        [HttpGet(nameof(GetDashBoard))]
        public IActionResult GetDashBoard()
        {
            return Ok("Working OnIt");
        }

        /// <summary>
        /// DoctorsBulkUpload
        /// </summary>
        /// <returns></returns>

        [HttpPost(nameof(DoctorsBulkUpload))]
        public IActionResult DoctorsBulkUpload()
        {
            return Ok("Working OnIt");
        }
    }
}
