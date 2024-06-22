using Application.EmailServices;
using Application.Hangfire;
using Domain.InterfaceRebositorys.UnitOfWork;
using Hangfire;

namespace Infrastructure.Hangefire;

public class Hangefireservices(
        IUnitOfWork _unitOfWork,
        IEmailSender _emailSender
    ) : IHangfireServices
{

    /// <summary>
    /// Start Timer To Check If The User Read In The Application Or No
    /// </summary>
    public void StartTimer(int id)
    {
        RecurringJob.AddOrUpdate(
                recurringJobId: $"CheckReadJob-{id}",
                methodCall: () => CheckRead(id),
                cronExpression: Cron.Daily);
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
        if (user is { ReadFrom: null, ReadTo: null } || (user is { ReadFrom: not null, ReadTo: not null } && user?.ReadTo!.Value.Hour - user?.ReadFrom!.Value.Hour < 1))
        {
            var emailBody = $@"
                <p>Dear {user?.UserName},</p>
                <p>Please remember to join and read at the bookstore.</p>
                <p>Best regards,<br/>Bookstore Team</p>";

            _emailSender.SendEmailAsync(user!.Email, "SBookStore", emailBody);
        }
    }
}
