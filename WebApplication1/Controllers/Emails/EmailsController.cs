using Application.EmailServices;
using Application.Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers.Email
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController(IEmailSender _emailSender) : ControllerBase
    {
        [HttpPost]
        [Route("Send")]
        public IActionResult Send(string email, string message, string subject)
        {
            _emailSender.SendEmailAsync(email, message, subject);
            return Ok();
        }
    }
}
