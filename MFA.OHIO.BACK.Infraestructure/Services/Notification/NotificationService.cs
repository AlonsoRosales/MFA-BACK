using MFA.OHIO.BACK.Application.Interfaces;
using MFA.OHIO.BACK.Infraestructure.Services.Notification.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Infraestructure.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationOptions _options;

        public NotificationService(IOptions<NotificationOptions> options)
        {
            _options = options.Value;
        }

        public async Task<bool> SendMailAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
