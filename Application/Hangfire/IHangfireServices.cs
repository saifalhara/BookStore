namespace Application.Hangfire;

public interface IHangfireServices
{
    void CheckRead(int id);
    void StartTimer(int id);
}
