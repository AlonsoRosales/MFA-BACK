using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MFA.OHIO.BACK.Infraestructure.Services.Notification.Options
{
    public class NotificationOptionsSetup: IConfigureOptions<NotificationOptions>
    {
        private const string ConfigurationSectionName = "EmailSettings";
        private readonly IConfiguration _configuration;

        public NotificationOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(NotificationOptions options)
        {
            _configuration.GetSection(ConfigurationSectionName).Bind(options);
        }
    }
}
