#if DEBUG
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppProject.Core.Controllers
{
    [Route("api/general/[controller]/[action]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSample()
        {
            var sampleData = new
            {
                Id = 1,
                Name = "Sample - mFF",
                Description = "This is a sample data response from the API."
            };

            return Ok(sampleData);
        }
    }
}

#endif