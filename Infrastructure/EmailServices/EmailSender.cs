using Application.EmailServices;
using Infrastructure.Options.Email;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.EmailServices;

public class EmailSender(IOptions<EmailOptions> options) : IEmailSender
{

    public readonly string Email  = options.Value.Email;
    public readonly string Password = options.Value.Password;

    public void SendEmailAsync(string email, string subject, string message)
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(Email);
        mailMessage.Subject = subject;
        mailMessage.To.Add(email);
        mailMessage.Body = message;

        var smtpClient = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            Credentials = new NetworkCredential(Email , Password),
            UseDefaultCredentials = false,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            EnableSsl = true
        };

        smtpClient.Send(mailMessage);
    }
}
