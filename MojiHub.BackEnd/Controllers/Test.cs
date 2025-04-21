using Microsoft.AspNetCore.Mvc;

namespace MojiHub.BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTestMessage()
        {
            return Ok(new { message = "سلام از بک‌اند .NET Core!", date = DateTime.Now });
        }

        [HttpPost]
        public IActionResult Echo([FromBody] string input)
        {
            return Ok(new { original = input, echoed = $"شما گفتید: {input}" });
        }
    }
}
