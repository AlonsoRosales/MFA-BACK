
namespace MFA.OHIO.BACK.Application.Interfaces
{
    public interface INotificationService
    {
        Task<bool> SendMailAsync(string token);
    }
}
