using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFA.OHIO.BACK.Application.Interfaces
{
    public interface INotificationService
    {
        Task<bool> SendMailAsync(string token);
    }
}
