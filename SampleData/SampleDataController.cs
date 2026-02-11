using Microsoft.AspNetCore.Mvc;

namespace Star.SampleData
{
    [ApiController]
    public class SampleDataController : Controller
    {
        [HttpGet("sampledata")]
        public IActionResult Get()
        {
            return Ok("SampleData");
        }
    }
}
