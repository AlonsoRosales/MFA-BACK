
namespace MFA.OHIO.BACK.Infraestructure.Services.Notification.Options
{
    public class NotificationOptions
    {
        public string SmtpServer { get; init; }
        public int Port { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public bool EnableSSL { get; init; }
    }
}
