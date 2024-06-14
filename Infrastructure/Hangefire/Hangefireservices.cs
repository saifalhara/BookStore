using Application.EmailServices;
using Application.Hangfire;
using Domain.InterfaceRebositorys.UnitOfWork;
using Hangfire;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Hangefire;

public class Hangefireservices(
        IUnitOfWork _unitOfWork,
        IEmailSender _emailSender,
        IHttpContextAccessor _httpContextAccessor
    ) : IHangfireServices
{
    

    /// <summary>
    /// Start Timer To Check If The User Read In The Application Or No
    /// </summary>
    public void StartTimer(int id)
    {
        RecurringJob.AddOrUpdate(() => CheckRead(id), Cron.Daily);
    }

    /// <summary>
    /// This is For Check If The User Read More Than One Hour Or No If Not Send Mail To Remaind Him
    /// </summary>
    /// <param name="id"></param>
    public void CheckRead(int id)
    {
        if (id == 0)
        {
            return;
        }
        var user = _unitOfWork._GenericUserRepository.GetByExpression((u => u.Id == id)).Result;
        if ((user.ReadTo.HasValue && user.ReadFrom.HasValue) || (user?.ReadTo!.Value.Hour - user?.ReadFrom!.Value.Hour < 1))
        {
            _emailSender.SendEmailAsync(user!.Email, "SBookStore", $@"<p>Dear {user.UserName},</p><p>Please remember to join and read at the bookstore.</p><p>Best regards,<br/>Bookstore Team</p>");
        }
    }
}
