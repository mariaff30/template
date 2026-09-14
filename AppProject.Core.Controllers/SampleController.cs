#if DEBUG
using AppProject.Resources;
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
                Name = "Sample - MFF",
                Description = "This is a sample data response from the API."
            };

            List<int> sampleNumbers = new List<int> { 3, 9, 43, 94, 5 };
            sampleNumbers = [.. sampleNumbers.OrderBy(n => n)];
            Console.WriteLine("Sorted Sample Numbers: " + string.Join(", ", sampleNumbers));


            return Ok(sampleData);
        }


        [HttpGet]
        public IActionResult GetCultureSample()
        {
            return this.Ok(StringResource.GetString("Sample_Message_Text"));
        }
    }
}

#endif