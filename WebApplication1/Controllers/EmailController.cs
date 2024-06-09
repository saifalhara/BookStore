using Application.EmailServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController(IEmailSender _emailSender) : ControllerBase
    {
        [HttpPost]
        [Route("Send")]
        public  IActionResult Send(string email , string message , string subject)
        {
            _emailSender.SendEmailAsync(email , message , subject);
            return Ok();
        }
    }
}
