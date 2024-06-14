using Application.Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.Hangfires
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController(IHangfireServices _hangfireServices) : ControllerBase
    {
        [HttpPost]
        [Route("HangeFire")]
        public IActionResult Hangfire()
        {
            _hangfireServices.StartTimer();
            return Ok();
        }

    }
}
